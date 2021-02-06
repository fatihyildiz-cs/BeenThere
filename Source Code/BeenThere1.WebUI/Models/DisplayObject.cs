using System;
using System.Collections.Generic;

namespace BeenThere1.WebUI.Models
{
    public class DisplayObject
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int LocationId { get; set; }
        public string Description { get; set; }
        public string CountryName { get; set; }
        public List<CategoryObject> Categories { get; set; }
    }
}
