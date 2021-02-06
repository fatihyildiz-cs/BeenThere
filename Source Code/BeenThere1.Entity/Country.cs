using System;
namespace BeenThere1.Entity
{
    public class Country
    {
        public int Id { get; set; }

        public CountryList CountryList { get; set; }

        public int CountryListId { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }
    }
}

