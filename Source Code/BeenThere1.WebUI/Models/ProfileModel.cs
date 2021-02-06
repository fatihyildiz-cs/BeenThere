using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.WebUI.Models
{
    public class ProfileModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ProfilePicUrl { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Hometown { get; set; }

        public string HomeCountry { get; set; }

        public string Bio { get; set; }

        public string Description { get; set; }

        public string PersonalWebsite { get; set; }

        public string InstagramId { get; set; }

        public string YoutubeId { get; set; }

        public bool CurrentlyTraveling { get; set; }

        public string CurrentCountry { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<string> VisitedCountries { get; set; }

        public List<string> AllCountries { get; set; }
    }
}
