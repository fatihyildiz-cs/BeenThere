using System;
using System.ComponentModel.DataAnnotations;

namespace BeenThere1.Entity
{
    public class LocationCategoryJunction
    {
        [Key]
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
