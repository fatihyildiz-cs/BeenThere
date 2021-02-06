using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeenThere1.WebUI.Models;
using BeenThere1.Entity;
using BeenThere1.Data.Abstract;
using BeenThere1.Business.Abstract;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using BeenThere1.Data.Concrete;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace BeenThere1.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExperienceService _ExperienceService;
        private readonly ILocationService _LocationService;
        private readonly ICategoryService _CategoryService;
        private readonly UserManager<BeenThereUser> _UserManager;

        public HomeController(ILogger<HomeController> logger, IExperienceService experienceService, ILocationService locationService, ICategoryService categoryService, UserManager<BeenThereUser> userManager)
        {
            _logger = logger;
            _ExperienceService = experienceService;
            _LocationService = locationService;
            _CategoryService = categoryService;
            _UserManager = userManager;
        }
        //var markerDisplayObject = _LocationService.GetAllLocationsWithCategories().Select(s => new DisplayObject { Name = s.Name, Latitude = s.Latitude, Longitude = s.Longitude, Description = s.Description, LocationId = s.LocationId, CountryName = s.Country, Categories = s.LocationCategoryJunctions.Select(s => new CategoryObject { CategoryName = s.Category.Name, CategoryUrl = s.Category.Url, CategoryId = s.Category.CategoryId }).ToList() });

        [HttpGet]
        public IActionResult Index()
        {
            var markerDisplayObject = _LocationService.GetAllLocationsWithCategories().Select(s => new DisplayObject { Name = s.Name, Latitude = s.Latitude, Longitude = s.Longitude, Description = s.Description, LocationId = s.LocationId, CountryName = s.Country, Categories = s.LocationCategoryJunctions.Select(s => new CategoryObject { CategoryName = s.Category.Name, CategoryUrl = s.Category.Url, CategoryId = s.Category.CategoryId }).ToList() });

            ViewBag.Markers = BuildDisplayString(markerDisplayObject);

            var countryList = _LocationService.GetAll().Select(s => s.Country).Distinct().ToList();

            var mapModel = new MapModel()
            {
                Countries = countryList.OrderBy(q => q).ToList(),
                AllCategories = _CategoryService.GetAll(),
                ChosenCategoryArray = new int[0]
            };

            return View(mapModel);
        }

        [HttpPost]
        public IActionResult FilterMarkers(FilterModel fm)
        {
            string newMarkerString;

            if (fm.filterCategoryIds != null)
            {
                newMarkerString = System.Text.Json.JsonSerializer.Serialize(_LocationService.LocationListByFilters(fm.filterCategoryIds, fm.countryChoice).Select(s => new DisplayObject { Name = s.Name, Latitude = s.Latitude, Longitude = s.Longitude, Description = s.Description, LocationId = s.LocationId, CountryName = s.Country, Categories = s.LocationCategoryJunctions.Select(s => new CategoryObject { CategoryName = s.Category.Name, CategoryUrl = s.Category.Url, CategoryId = s.Category.CategoryId }).ToList() }));
            }
            else
            {
                newMarkerString = System.Text.Json.JsonSerializer.Serialize(_LocationService.LocationListByFilters(null, fm.countryChoice).Select(s => new DisplayObject { Name = s.Name, Latitude = s.Latitude, Longitude = s.Longitude, Description = s.Description, LocationId = s.LocationId, CountryName = s.Country, Categories = s.LocationCategoryJunctions.Select(s => new CategoryObject { CategoryName = s.Category.Name, CategoryUrl = s.Category.Url, CategoryId = s.Category.CategoryId }).ToList() }));
            }

            var data = new FilterModel()
            {
                markerString = newMarkerString
            };
            return Json(data);
        }

        private string BuildDisplayString(IEnumerable<DisplayObject> displayObject)
        {
            StringBuilder markerDisplayString = new StringBuilder();
            using (StringWriter sw = new StringWriter(markerDisplayString))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                writer.QuoteChar = '\'';

                Newtonsoft.Json.JsonSerializer ser = new Newtonsoft.Json.JsonSerializer();
                ser.Serialize(writer, displayObject);
            }
            return markerDisplayString.ToString();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
