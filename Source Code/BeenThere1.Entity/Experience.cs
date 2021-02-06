using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeenThere1.Entity
{
    public class Experience
    {

        public int ExperienceId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Body { get; set; }

        public string Address { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateOfUpdate { get; set; } = DateTime.Now;

        public Location Location { get; set; }

        public int? LocationId { get; set; }

        public List<ExperienceCategoryJunction> ExperienceCategoryJunctions { get; set; }

        public List<Comment> Comments { get; set; }

        public string BeenThereUserId { get; set; }
    }
}
