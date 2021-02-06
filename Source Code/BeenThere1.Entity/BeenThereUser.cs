using System;
using System.Collections.Generic;
using BeenThere1.Entity;
using Microsoft.AspNetCore.Identity;

namespace BeenThere1.Entity
{
    public class BeenThereUser: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

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

        public string ProfilePicUrl { get; set; }

        public List<Experience> Experiences { get; set; }

        public string VisitedCountryCodesList { get; set; }


    }
}
