using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeenThere1.Business.Abstract;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;
using BeenThere1.WebUI.Extensions;
using BeenThere1.WebUI.Identity;
using BeenThere1.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeenThere1.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly IExperienceService _ExperienceService;
        private readonly ICategoryService _CategoryService;
        private readonly ILocationService _LocationService;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly UserManager<BeenThereUser> _UserManager;

        public AdminController(IExperienceService experienceService, ICategoryService categoryService, ILocationService locationService ,RoleManager<IdentityRole> roleManager, UserManager<BeenThereUser> userManager)
        {
            _ExperienceService = experienceService;
            _CategoryService = categoryService;
            _LocationService = locationService;
            _RoleManager = roleManager;
            _UserManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        


        public IActionResult RoleList()
        {
            return View(_RoleManager.Roles);
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _RoleManager.CreateAsync(new IdentityRole(model.Name));

                if (result.Succeeded)
                {
                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "Success",
                        Message = $"The role {model.Name} has been created.",
                        AlertType = "success"
                    });

                    return Redirect("/admin/rolelist");
                }
                else
                {
                    foreach (var errorLog in result.Errors)
                    {
                        ModelState.AddModelError("", errorLog.Description);
                    }
                }

                return View(model);


            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RoleEdit(string id)
        {
            var role = await _RoleManager.FindByIdAsync(id);

            var roleMembers = new List<BeenThereUser>();

            var roleNonMembers = new List<BeenThereUser>();

            foreach (var user in _UserManager.Users)
            {
                if(await _UserManager.IsInRoleAsync(user, role.Name))
                {
                    roleMembers.Add(user);
                }
                else
                {
                    roleNonMembers.Add(user);
                }
                
            }
            var model = new RoleEditGetRequestModel()
            {
                Role = role,
                RoleMembers = roleMembers,
                RoleNonMembers = roleNonMembers
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditPostRequestModel model)
        {
            if (ModelState.IsValid) {


                var roleToBeEdited = await _RoleManager.FindByIdAsync(model.RoleID);

                roleToBeEdited.Name = model.RoleName;

                var nameUpdateResult = await _RoleManager.UpdateAsync(roleToBeEdited);

                if (nameUpdateResult.Succeeded) { 

                foreach (var UserIDToBeAdded in model.IdsThatWillBeAdded ?? new string[] { })
                {
                    var user = await _UserManager.FindByIdAsync(UserIDToBeAdded);

                    if(user!= null)
                    {
                        var result = await _UserManager.AddToRoleAsync(user, model.RoleName);

                    }
                }

                foreach (var UserIdToBeDeleted in model.IdsThatWillBeDeleted ?? new string[] { })
                {
                    var user = await _UserManager.FindByIdAsync(UserIdToBeDeleted);

                    if (user != null)
                    {
                        var result = await _UserManager.RemoveFromRoleAsync(user, model.RoleName);

                    }
                }

                return Redirect("/admin/roleedit/"+ model.RoleID);
                }

                return View();
            }

            return View();
        }

        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _RoleManager.FindByIdAsync(id);

            var result = await _RoleManager.DeleteAsync(role);

            TempData.Put("message", new AlertMessage()
            {
                Title = "Success",
                Message = $"The role {role.Name} has been deleted.",
                AlertType = "warning"
            });

            return Redirect("/admin/rolelist");
        }

        public IActionResult UserList()
        {
            var userList = _UserManager.Users;

            return View(userList);
        }

        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _UserManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _UserManager.DeleteAsync(user);

            }

            return Redirect("/admin/userlist");

        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new BeenThereUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName
                };

                var result = await _UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Redirect("/admin/userlist");
                }

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _UserManager.FindByIdAsync(id);

            if (user != null)
            {
                var roleNamesOfThisUser = await _UserManager.GetRolesAsync(user);
                var allRoleNames = _RoleManager.Roles.Select(s => s.Name).ToList();


                var userModel = new UserModel()
                {
                    UserID = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,

                    RoleNamesOfThisUser = roleNamesOfThisUser,
                    AllRoleNames = allRoleNames

                };

                return View(userModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel, string[] assignedRoleNames)
        {
            if (ModelState.IsValid)
            {
                assignedRoleNames = assignedRoleNames ?? new string[] { };
                
                var user = await _UserManager.FindByIdAsync(userModel.UserID);
                var allRoleNames = _RoleManager.Roles.Select(s => s.Name).ToList();

                if (user != null)
                {
                    var currentRoleNames = await _UserManager.GetRolesAsync(user);
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.UserName = userModel.UserName;
                    user.Email = userModel.Email;

                    var result = await _UserManager.UpdateAsync(user);

                    

                    if (result.Succeeded)
                    {
                        await _UserManager.RemoveFromRolesAsync(user, currentRoleNames.Except(assignedRoleNames));
                        await _UserManager.AddToRolesAsync(user, assignedRoleNames.Except(currentRoleNames));


                        return Redirect("/admin/userlist");
                    }
                    return NotFound();  
                }
                return NotFound();
            }
            return View(userModel);
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category()
                {
                    Name = categoryModel.Name,
                    Url = categoryModel.Url,
                    Approved = true
                };

                _CategoryService.Create(newCategory);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Success",
                    Message = $"The category {categoryModel.Name} has been created.",
                    AlertType = "success"
                });

                return Redirect("/admin/categorylist");
            }
            return View();
        }

        [HttpPost]
        public IActionResult CategoryApprove(int categoryId, string categoryName, string categoryUrl)
        {
            if (ModelState.IsValid)
            {
                var categoryToBeApproved = _CategoryService.GetById(categoryId);


                categoryToBeApproved.Name = categoryName;
                categoryToBeApproved.Url = categoryUrl;
                categoryToBeApproved.Approved = true;

                _CategoryService.Update(categoryToBeApproved);

                TempData.Put("message", new AlertMessage()
                {
                    Title = "Success",
                    Message = $"The role {categoryToBeApproved.Name} has been approved.",
                    AlertType = "success"
                });

                return Redirect("/admin/categorylist");
            }
            return View();
        }

        public IActionResult CategoryDisapprove(int id)
        {
            var categoryToBeDisapproved = _CategoryService.GetById(id);

            categoryToBeDisapproved.Approved = false;

            _CategoryService.Update(categoryToBeDisapproved);

            TempData.Put("message", new AlertMessage()
            {
                Title = "Success",
                Message = $"The role {categoryToBeDisapproved.Name} has been disapproved.",
                AlertType = "success"
            });
            return Redirect("/admin/categorylist");
        }

        [HttpPost]
        public IActionResult CategoryRequest(string requestedCategoryName)
        {
            var newCategory = new Category()
            {
                Name = requestedCategoryName,
                Approved = false
            };

            _CategoryService.Create(newCategory);

            string result = requestedCategoryName;

            return Json(result);
        }

        public IActionResult CategoryList()
        {
            var categoryList = new CategoryListModel()
            {
                Categories = _CategoryService.GetAll()
            };

            return View(categoryList);
        }

        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if(id != null)
            {

                var category = _CategoryService.GetById((int)id);
                if (category != null)
                {
                    var categoryModel = new CategoryModel()
                    {
                        Id = category.CategoryId,
                        Name = category.Name,
                        Url = category.Url
                    };

                    return View(categoryModel);
                }

                return NotFound();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel categoryModel)
        {
                if (ModelState.IsValid)
                {
                    var categoryToBeEdited = _CategoryService.GetById(categoryModel.Id);

                    if(categoryToBeEdited != null)
                    { 

                    categoryToBeEdited.Name = categoryModel.Name;
                    categoryToBeEdited.Url = categoryModel.Url;

                    _CategoryService.Update(categoryToBeEdited);

                    return Redirect("/admin/CategoryList");
                    }
                return NotFound();
            }
            return View(categoryModel);
        }

        [HttpGet]
        public IActionResult CategoryDetails(int? id)
        {
            if(id != null)
            {
                var category = _CategoryService.GetCategoryWithLocationsById((int)id);

                if(category != null)
                {
                    var categoryModel = new CategoryModel()
                    {
                        Id = category.CategoryId,
                        Name = category.Name,
                        Url = category.Url,
                        Locations = category.LocationCategoryJunctions.Select(q => q.Location).ToList()

                    };

                    return View(categoryModel);
                }
                return NotFound();
            }
            return NotFound();
        }

        public IActionResult CategoryDelete(int id)
        {
            var categoryToBeDeleted = _CategoryService.GetById(id);

            if (categoryToBeDeleted != null)
            {
                _CategoryService.Delete(categoryToBeDeleted);

                return Redirect("/admin/categorylist");
            }

            return Redirect("~/");



        }

        [HttpGet]
        public IActionResult LocationEdit(int? id)
        {
            if(id != null)
            {
                Location location = _LocationService.GetLocationWithCategoriesById((int)id);

                if (location != null)
                {
                    var allCategories = _CategoryService.GetAll().ToList();
                    var categoriesOfThisLocation = location.LocationCategoryJunctions.Select(s => s.Category).ToList();
                    var experiencesOfThisLocation = _ExperienceService.GetAll().Where(e => e.LocationId == id).ToList();
                    var locationModel = new LocationModel()
                    {
                        Name = location.Name,
                        Country = location.Country,
                        City = location.City,
                        State = location.State,
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        DistanceToCenter = location.DistanceToCenter,
                        CategoriesOfThisLocation = categoriesOfThisLocation,
                        AllCategories = allCategories,
                        ExperiencesOfThisLocation = experiencesOfThisLocation

                    };
                    return View(locationModel);
                };
                return NotFound();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult LocationEdit(LocationModel locationModel, int[] selectedCategoryIds)
        {

            if (ModelState.IsValid)
            {
                var locationToBeEdited = _LocationService.GetById(locationModel.Id);

                if(locationToBeEdited != null)
                {
                    locationToBeEdited.Name = locationModel.Name;
                    locationToBeEdited.Country = locationModel.Country;
                    locationToBeEdited.City = locationModel.City;
                    locationToBeEdited.State = locationModel.State;
                    locationToBeEdited.Latitude = locationModel.Latitude;
                    locationToBeEdited.Longitude = locationModel.Longitude;
                    locationToBeEdited.DistanceToCenter = locationModel.DistanceToCenter;

                    _LocationService.Update(locationToBeEdited, selectedCategoryIds);

                    return Redirect("/admin/locationlist/");
                }
                return NotFound();
            }
            return View(locationModel);
        }

        public IActionResult DeleteLocationFromCategory(int locationId, int categoryId)
        {
            _CategoryService.DeleteLocationFromCategory(locationId, categoryId);


            return Redirect("/admin/categorydetails/"+categoryId);
        }

        public IActionResult LocationList()
        {

            var model = new LocationListModel()
            {
                Locations = _LocationService.GetAll()
            };


            return View(model);
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

    }
}
