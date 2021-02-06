using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class MapModel
    {
        public List<string> Countries { get; set; }

        public List<Category> AllCategories { get; set; }

        public string ChosenCountryName { get; set; }

        public int[] ChosenCategoryArray { get; set; }

        public string MarkerDisplayString { get; set; }
    }
}
