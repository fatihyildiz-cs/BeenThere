using System;
namespace BeenThere1.WebUI.Models
{
    public class FilterModel
    {
        public string countryChoice { get; set; }

        public int[] filterCategoryIds { get; set; }

        public string markerString { get; set; }
    }
}
