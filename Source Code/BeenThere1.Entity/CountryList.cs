using System;
using System.Collections.Generic;

namespace BeenThere1.Entity
{
    public class CountryList
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public List<Country> Countries { get; set; }


    }
}
