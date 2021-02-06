using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public List<Location> Locations { get; set; }

    }

}