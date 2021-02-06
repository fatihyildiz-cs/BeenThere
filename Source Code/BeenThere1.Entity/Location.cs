using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeenThere1.Entity
{

    public class Location
    {

        public Location()
        {
            this.Experiences = new List<Experience>();
        }

        public int LocationId { get; set; }

        public string PlaceId { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Longitude { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Address { get; set; }

        public string GoogleMapsUrl { get; set; }

        public string Coordinates { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public int VisitCount { get; set; }

        public string Type { get; set; }

        public decimal DistanceToCenter { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<LocationCategoryJunction> LocationCategoryJunctions { get; set; }

    }
}
