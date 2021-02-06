using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class PageInfo
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public string searchKeyword { get; set; }

        public int[] filterCategoryIds { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }

    public class ExperienceListModel
    {

        public List<Experience> Experiences { get; set; }

        public List<Category> AllCategories { get; set; }

        public Location Location { get; set; }

        public int[] FilterCategoryIds{ get; set; }

        public string SearchKeyword { get; set; }

        public string ChosenCountryCode { get; set; }

        public PageInfo PageInfo { get; set; }

        



    }
}
