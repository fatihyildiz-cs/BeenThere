using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeenThere1.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public bool Approved { get; set; }

        public List<LocationCategoryJunction> LocationCategoryJunctions { get; set; }

        public List<ExperienceCategoryJunction> ExperienceCategoryJunctions { get; set; }

    }
}
