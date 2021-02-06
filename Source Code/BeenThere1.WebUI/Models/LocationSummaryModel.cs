using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class LocationSummaryModel
    {
        public Location Location { get; set; }

        public List<Category> CategoriesOfThisLocation { get; set; }

        public List<Experience> ExperiencesOfThisLocation { get; set; }

        public List<string> LastTravelersHere { get; set; }
    }
}
