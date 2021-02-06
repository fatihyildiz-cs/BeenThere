using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class LocationModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Address { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Coordinates { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public int VisitCount { get; set; }

        public decimal DistanceToCenter { get; set; }

        public List<Category> CategoriesOfThisLocation { get; set; }

        public List<Category> AllCategories { get; set; }

        public List<Experience> ExperiencesOfThisLocation { get; set; }


    }
}
