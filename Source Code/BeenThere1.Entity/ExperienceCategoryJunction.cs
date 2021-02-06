using System;
using System.ComponentModel.DataAnnotations;

namespace BeenThere1.Entity
{
    public class ExperienceCategoryJunction
    {
        [Key]
        public int ExperienceId { get; set; }

        public Experience Experience { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
