using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class ExperienceCreateUpdateModel
    {
        public int ExperienceId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string AuthorProfilePicUrl { get; set; }

        [Required]
        public string Body { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public int? LocationID { get; set; }

        public Location LocationOfExperience { get; set; }

        public int? LocationChoiceId { get; set; }

        public List<Category> CategoriesOfThisListing { get; set; }

        public List<Category> AllCategories { get; set; }

        public List<Location> AllLocations { get; set; }

        public List<Comment> CommentsOfThisListing { get; set; }

        public Comment NewComment { get; set; }

        public bool ExperienceEditModelStateInvalid { get; set; }



    }
}

