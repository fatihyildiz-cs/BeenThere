using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class CategorySummaryModel
    {

        public Category Category { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<Location> Locations { get; set; }

    }
}
