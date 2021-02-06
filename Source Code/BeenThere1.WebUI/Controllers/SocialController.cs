using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BeenThere1.Business.Abstract;
using BeenThere1.Data.Abstract;
using BeenThere1.Data.Concrete;
using BeenThere1.Entity;
using BeenThere1.WebUI.Extensions;
using BeenThere1.WebUI.Identity;
using BeenThere1.WebUI.Models;
using Bia.Countries.Iso3166;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeenThere1.WebUI.Controllers
{

    public class SocialController : Controller
    {
        private readonly UserManager<BeenThereUser> _UserManager;
        private readonly IExperienceService _ExperienceService;
        private readonly ILocationService _LocationService;
        private readonly ICategoryService _CategoryService;
        private readonly ICommentService _CommentService;

        public SocialController(UserManager<BeenThereUser> userManager, IExperienceService experienceService, ILocationService locationService, ICategoryService categoryService, ICommentService commentService)
        {
            _UserManager = userManager;
            _ExperienceService = experienceService;
            _LocationService = locationService;
            _CategoryService = categoryService;
            _CommentService = commentService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ExperienceCreate(int? id)
        {

            var allCategories = _CategoryService.GetAll().ToList();

            var model = new ExperienceCreateUpdateModel()
            {
                AllCategories = allCategories,
                AllLocations = _LocationService.GetAll(),
                LocationOfExperience = (id == null) ? new Location() : _LocationService.GetById((int)id)

            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ExperienceCreate(ExperienceCreateUpdateModel model, int[] selectedCategoryIds, IFormFile file)
        {
            if (ModelState.IsValid) 
            {

                var user = await _UserManager.FindByNameAsync(User.Identity.Name);

                var entity = new Experience()
                {
                    Name = model.Name,
                    Title = model.Title,
                    Author = model.Author,
                    Body = model.Body,
                    LocationId = model.LocationOfExperience.LocationId,
                    BeenThereUserId = user.Id,
                    ImageUrl = "defaultExperiencePic.jpg"
                };
                var locationOfExperience = _LocationService.GetById(model.LocationOfExperience.LocationId);

                await UpdateCountryCodeList(user.Id.ToString(), locationOfExperience.CountryCode, null);

                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//img", randomName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }


                _ExperienceService.Create(entity);

                _ExperienceService.AddCategoriesToExperience(entity, selectedCategoryIds);

                if (model.LocationOfExperience.LocationId > 0)
                {
                    var locationToBeEdited = _LocationService.GetById(model.LocationOfExperience.LocationId);

                    _LocationService.AttachCategoriesToLocation(locationToBeEdited, selectedCategoryIds);
                }

                return Redirect("/social/experiencedetails/" + entity.ExperienceId);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ExperienceList(int[] filterCategoryIds, int page = 1)
        {
            const int pageSize = 6;

            var experiencesToDisplay = _ExperienceService.ExperienceListByFilters(filterCategoryIds, "", "", page, pageSize);

            var totalNumberOfItemsToDisplay = _ExperienceService.GetFilteredExperienceCount(filterCategoryIds, "", "");

            var experienceListModel = new ExperienceListModel()
            {
                Experiences = experiencesToDisplay,
                AllCategories = _CategoryService.GetAll(),
                FilterCategoryIds = filterCategoryIds,

                PageInfo = new PageInfo()
                {

                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = totalNumberOfItemsToDisplay,
                    filterCategoryIds = filterCategoryIds
                }
            };


            return View(experienceListModel);
        }

        [HttpPost]
        public IActionResult ExperienceList(int[] filterCategoryIds, string searchKeyWord, string countryCode, int page = 1)
        {
            const int pageSize = 6;

            Console.WriteLine(countryCode);

            var experiencesToDisplay = _ExperienceService.ExperienceListByFilters(filterCategoryIds, searchKeyWord, countryCode, page, pageSize);

            var totalNumberOfItemsToDisplay = _ExperienceService.GetFilteredExperienceCount(filterCategoryIds, searchKeyWord, countryCode);

            var experienceListModel = new ExperienceListModel()
            {
                Experiences = experiencesToDisplay,
                AllCategories = _CategoryService.GetAll(),
                FilterCategoryIds = filterCategoryIds,
                ChosenCountryCode = countryCode,

                PageInfo = new PageInfo()
                {

                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = totalNumberOfItemsToDisplay,
                    filterCategoryIds = filterCategoryIds
                }
            };

            return View(experienceListModel);
        }

        public async Task<IActionResult> ExperienceDetails(int id)
        {
            var experience = _ExperienceService.GetExperienceWithCategoriesById(id);

            if (experience == null)
            {
                return NotFound();
            }

            var categoriesOfExperience = experience.ExperienceCategoryJunctions.Select(s => s.Category).ToList();
            var locationOfExperience = new Location();
            var commentsOfExperience = _CommentService.GetAll().Where(i => i.ExperienceId == id).OrderByDescending(x => x.CommentId).ToList();
            var user = await _UserManager.FindByNameAsync(experience.Author);

            var model = new ExperienceCreateUpdateModel()
            {
                ExperienceId = experience.ExperienceId,
                Name = experience.Name,
                Title = experience.Title,
                Author = experience.Author,
                Body = experience.Body,
                ImageUrl = experience.ImageUrl,
                CategoriesOfThisListing = categoriesOfExperience,
                CommentsOfThisListing = commentsOfExperience,
                AllCategories = _CategoryService.GetAll(),
                CreationDate = experience.DateOfCreation,
                AuthorProfilePicUrl = user.ProfilePicUrl
            };

            if (experience.LocationId != null)
            {
                model.LocationOfExperience = locationOfExperience = _LocationService.GetById((int)experience.LocationId);
            };


            return View(model);
        }

        [HttpGet]
        public IActionResult ExperienceEdit(int id)
        {
            var experience = _ExperienceService.GetExperienceWithCategoriesById(id);

            if (experience != null)
            {
                var allCategories = _CategoryService.GetAll().ToList();
                var categoriesOfExperience = experience.ExperienceCategoryJunctions.Select(s => s.Category).ToList();
                var locationId = experience.LocationId;

                var model = new ExperienceCreateUpdateModel()
                {

                    ExperienceId = experience.ExperienceId,
                    Name = experience.Name,
                    Title = experience.Title,
                    Author = experience.Author,
                    Body = experience.Body,
                    ImageUrl = experience.ImageUrl,
                    AllCategories = allCategories,
                    AllLocations = _LocationService.GetAll(),
                    CategoriesOfThisListing = categoriesOfExperience,
                    LocationID = locationId
                };
                return View(model);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> ExperienceEdit(ExperienceCreateUpdateModel experienceModel, int[] selectedCategoryIds, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                var experienceToBeEdited = _ExperienceService.GetById(experienceModel.ExperienceId);

                if (experienceToBeEdited != null)
                {
                    experienceToBeEdited.Name = experienceModel.Name;
                    experienceToBeEdited.Title = experienceModel.Title;
                    experienceToBeEdited.Body = experienceModel.Body;
                    if(experienceModel.LocationChoiceId != null)
                    {
                        experienceToBeEdited.LocationId = experienceModel.LocationChoiceId;
                    }
                    

                    if (file != null)
                    {
                        var extention = Path.GetExtension(file.FileName);
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                        experienceToBeEdited.ImageUrl = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//img", randomName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }



                    _ExperienceService.Update(experienceToBeEdited, selectedCategoryIds);

                    return Redirect("/social/experiencedetails/" + experienceModel.ExperienceId);
                }
                return NotFound();
            }
            experienceModel.ExperienceEditModelStateInvalid = true;

            return View("experiencedetails" ,experienceModel);

        }

        public IActionResult ExperienceDelete(int id)
        {
            var experienceToBeDeleted = _ExperienceService.GetById(id);

            if (experienceToBeDeleted != null)
            {
                _ExperienceService.Delete(experienceToBeDeleted);
            }

            return Redirect("/social/experiencelist");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LocationCreate(decimal latitude, decimal longitude, string name, string city, string state, string country, string countryCode, string address, string route, string placeId, string website, string phoneNumber, string url)
        {
            var user = await _UserManager.FindByNameAsync(User.Identity.Name);

            var locationToBeCreated = new Location();

            if (placeId != null)
            {
                var location = _LocationService.GetLocationByPlaceId(placeId);
                if (location == null)
                {
                    locationToBeCreated = new Location()
                    {
                        Latitude = latitude,
                        Longitude = longitude,
                        DistanceToCenter = 0,
                        VisitCount = 0,
                        Name = name,
                        City = city,
                        Country = country,
                        CountryCode = countryCode,
                        Address = address + " " + route,
                        State = state,
                        PlaceId = placeId,
                        Website = website,
                        PhoneNumber = phoneNumber,
                        GoogleMapsUrl = url
                    };

                    if (locationToBeCreated.City == null)
                    {
                        locationToBeCreated.City = locationToBeCreated.State;
                        locationToBeCreated.State = null;

                    }
                    _LocationService.Create(locationToBeCreated);

                    //add the country to the visited country list:
                    

                    await UpdateCountryCodeList(user.Id.ToString(), countryCode, null);

                    return Redirect("experiencecreate/" + locationToBeCreated.LocationId);
                }
                else
                {
                    await UpdateCountryCodeList(user.Id.ToString(), countryCode, null);

                    return Redirect("experiencecreate/" + location.LocationId);
                }

            }
            else
            {
                locationToBeCreated = new Location()
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    DistanceToCenter = 0,
                    VisitCount = 0,
                    Name = name,
                    City = city,
                    Country = (country == null) ? Countries.GetCountryByAlpha2(countryCode).ShortName : country,
                    CountryCode = countryCode,
                    Address = address + " " + route,
                    State = state,
                    PlaceId = placeId,
                    Website = website,
                    PhoneNumber = phoneNumber,
                    GoogleMapsUrl = "https://www.google.com/maps/search/?api=1&query=" + latitude + "," + longitude
                };

                var countryToAdd = Countries.GetCountryByShortName(locationToBeCreated.Country);

                if (countryToAdd != null)
                {
                    await UpdateCountryCodeList(user.Id.ToString(), countryToAdd.Alpha2.ToString(), null);

                }

                _LocationService.Create(locationToBeCreated);

                return Redirect("experiencecreate/" + locationToBeCreated.LocationId);
            }

        }

        public IActionResult LocationDelete(int id)
        {
            var locationToBeDeleted = _LocationService.GetById(id);

            if (locationToBeDeleted != null)
            {
                var experiencesToEdit = _ExperienceService.GetAll().Where(e => e.LocationId == id);

                foreach (var experience in experiencesToEdit)
                {
                    experience.LocationId = null;

                    _ExperienceService.Update(experience);
                }

                _LocationService.Delete(locationToBeDeleted);
            }

            return Redirect("/admin/locationlist");
        }

        public IActionResult LocationSummary(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationToBeSummarized = _LocationService.GetById((int)id);

            if (locationToBeSummarized == null)
            {
                return NotFound();
            }

            var locationSummaryModel = new LocationSummaryModel()
            {
                Location = locationToBeSummarized,
                CategoriesOfThisLocation = _LocationService.GetLocationWithCategoriesById((int)id).LocationCategoryJunctions.Select(s => s.Category).ToList(),
                ExperiencesOfThisLocation = _ExperienceService.GetExperiencesWithCategoriesByLocationId((int)id),
                LastTravelersHere = _ExperienceService.GetAll().Where(e => e.LocationId == (int)id).Take(3).Select(e => e.Author).ToList()

            };

            return View(locationSummaryModel);
        }

        [HttpPost]
        public async Task<IActionResult> CommentCreate(string author, string commentTitle, string commentBody, int experienceId)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByNameAsync(author);

                var comment = new Comment()
                {
                    Author = author,
                    Title = commentTitle,
                    Body = commentBody,
                    ExperienceId = experienceId,
                    AuthorProfilePic = user.ProfilePicUrl
                };

                _CommentService.Create(comment);

                return Redirect("/social/experiencedetails/" + experienceId);
            }

            return View();
        }

        public IActionResult CommentDelete(int id)
        {
            var commentToBeDeleted = _CommentService.GetById(id);
            var experienceId = commentToBeDeleted.ExperienceId;

            if (commentToBeDeleted != null)
            {
                _CommentService.Delete(commentToBeDeleted);
            }

            return Redirect("/social/experiencedetails/" + experienceId);
        }

        [HttpGet]
        public IActionResult CommentEdit(int id)
        {
            var commentToBeEdited = _CommentService.GetById(id);

            if (commentToBeEdited != null)
            {
                var commentModel = new CommentModel()
                {
                    CommentId = commentToBeEdited.CommentId,
                    Title = commentToBeEdited.Title,
                    Body = commentToBeEdited.Body,
                    ExperienceId = commentToBeEdited.ExperienceId
                };

                return View(commentModel);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CommentEdit(int commentEditId, string commentEditTitle, string commentEditBody)
        {
            
                var commentToBeEdited = _CommentService.GetById(commentEditId);

                if (commentToBeEdited != null)
                {
                    commentToBeEdited.Title = commentEditTitle;
                    commentToBeEdited.Body = commentEditBody;

                    _CommentService.Update(commentToBeEdited);

                    return Redirect("/social/experiencedetails/" + commentToBeEdited.ExperienceId);
                }

                return NotFound();

        }

        [HttpGet]
        public async Task<IActionResult> Profile2(string id)
        {
            var user = await _UserManager.FindByNameAsync(id);

            var profileModel = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + user.LastName,
                Email = user.Email,
                Age = DateTime.Now.AddYears(-user.DateOfBirth.Year).Year,
                Hometown = user.Hometown,
                HomeCountry = user.HomeCountry,
                Bio = user.Bio,
                Description = user.Description,
                PersonalWebsite = user.PersonalWebsite,
                InstagramId = user.InstagramId,
                YoutubeId = user.YoutubeId,
                CurrentCountry = user.CurrentCountry,
                CurrentlyTraveling = user.CurrentlyTraveling,
                ProfilePicUrl = user.ProfilePicUrl,
                VisitedCountries = user.VisitedCountryCodesList.Split(',').OrderBy(q => q).ToList(),
                DateOfBirth = user.DateOfBirth,

                Experiences = _ExperienceService.AllExperiencesWithCategories().Where(e => e.Author == user.UserName).ToList(),
            };

            ViewBag.MapDisplay = TransformToJsArray(user.VisitedCountryCodesList);

            return View(profileModel);
        }

        private string TransformToJsArray(string countryCodeList)
        {
            var listOfCountryCodes = countryCodeList.Split(',').ToList();
            var st = "[";
            foreach (var code in listOfCountryCodes)
            {
                st = st + "'" + code + "',";
            }
            st = st + "]";
            return st;
        }

        [HttpGet]
        public async Task<IActionResult> ProfileEdit(string id)
        {
            var user = await _UserManager.FindByIdAsync(id);

            var profileModel = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + user.LastName,
                Age = user.Age,
                Hometown = user.Hometown,
                HomeCountry = user.HomeCountry,
                Bio = user.Bio,
                Description = user.Description,
                PersonalWebsite = user.PersonalWebsite,
                InstagramId = user.InstagramId,
                YoutubeId = user.YoutubeId,
                CurrentCountry = user.CurrentCountry,
                CurrentlyTraveling = user.CurrentlyTraveling,
                ProfilePicUrl = user.ProfilePicUrl
            };

            return View(profileModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(ProfileModel profileModel, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByIdAsync(profileModel.UserId);

                if (user != null)
                {
                    user.DateOfBirth = profileModel.DateOfBirth;
                    user.Bio = profileModel.Bio;
                    user.Description = profileModel.Description;
                    user.InstagramId = profileModel.InstagramId;
                    user.YoutubeId = profileModel.YoutubeId;
                    user.HomeCountry = profileModel.HomeCountry;
                    user.Hometown = profileModel.Hometown;
                    user.PersonalWebsite = profileModel.PersonalWebsite;
                    user.CurrentlyTraveling = profileModel.CurrentlyTraveling;
                    user.CurrentCountry = profileModel.CurrentCountry;

                    if (file != null)
                    {
                        var extention = Path.GetExtension(file.FileName);
                        var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                        user.ProfilePicUrl = randomName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//img", randomName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    await _UserManager.UpdateAsync(user);

                    return Redirect("/social/profile2/" + user.UserName);
                }

                return NotFound();

                
            }

            return View(profileModel);
        }

        private async Task UpdateCountryCodeList(string userId, string toBeAdded, string toBeRemoved)
        {
            using (var context = new BTContext())
            {
                var user = await _UserManager.FindByIdAsync(userId);
                var visitedCountries = new List<string>();
                if (!string.IsNullOrWhiteSpace(user.VisitedCountryCodesList))
                {
                    visitedCountries = user.VisitedCountryCodesList.Split(',').ToList();
                }
                if (!string.IsNullOrWhiteSpace(toBeAdded) && !visitedCountries.Contains(toBeAdded))
                {
                    visitedCountries.Add(toBeAdded);
                };
                if (!string.IsNullOrWhiteSpace(toBeRemoved) && visitedCountries.Contains(toBeRemoved))
                {
                    visitedCountries.Remove(toBeRemoved);
                };
                user.VisitedCountryCodesList = string.Join(",", visitedCountries);

                await _UserManager.UpdateAsync(user);
            }
        }

        public IActionResult CategorySummary(string url)
        {
            int pageSize = 6;

            if (!string.IsNullOrWhiteSpace(url))
            {
                var categoryToBeSummarized = _CategoryService.GetByUrl(url);

                if (categoryToBeSummarized != null)
                {
                    int[] categoryId = { categoryToBeSummarized.CategoryId };

                    var categorySummaryModel = new CategorySummaryModel()
                    {
                        Category = categoryToBeSummarized,
                        Experiences = _ExperienceService.ExperienceListByFilters(categoryId, "","", 1, pageSize),
                        Locations = _LocationService.GetLocationsByCategoryId(categoryToBeSummarized.CategoryId)
                    };



                    return View(categorySummaryModel);
                }

                return NotFound();
            }


            return NotFound();
        }




    }


}
