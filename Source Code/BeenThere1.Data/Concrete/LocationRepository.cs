using System;
using System.Collections.Generic;
using System.Linq;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;
using Microsoft.EntityFrameworkCore;

namespace BeenThere1.Data.Concrete
{
    public class LocationRepository: GenericRepository<Location, BTContext>, ILocationRepository
    {
        public LocationRepository()
        {
        }

        public Location GetLocationWithCategoriesById(int locationId)
        {
            using(var context = new BTContext())
            {
                return context.Locations.Where(l => l.LocationId == locationId)
                                        .Include(l => l.LocationCategoryJunctions)
                                        .ThenInclude(l => l.Category)
                                        .FirstOrDefault();
            }
        }

        public Location GetLocationWithExperiencesById(int id)
        {
            using(var context = new BTContext())
            {
                return context.Locations.Where(l => l.LocationId == id)
                                        .Include(l => l.Experiences)
                                        .FirstOrDefault();
            }
        }

        public Location GetLocationWithExperiencesAndCategoriesById(int id)
        {
            using (var context = new BTContext())
            {
                return context.Locations.Where(l => l.LocationId == id)
                                        .Include(l => l.LocationCategoryJunctions)
                                        .ThenInclude(l => l.Category)
                                        .Include(l => l.Experiences)
                                        .FirstOrDefault();
            }
        }

        public void Update(Location locationToBeEdited, int[] selectedCategoryIds)
        {
            using(var context = new BTContext())
            {
                var location = context.Locations.Include(i => i.LocationCategoryJunctions)
                                                .Where(i => i.LocationId == locationToBeEdited.LocationId)
                                                .FirstOrDefault();

                if(location != null)
                {
                    location.Name = locationToBeEdited.Name;
                    location.Country = locationToBeEdited.Country;
                    location.City = locationToBeEdited.City;
                    location.State = locationToBeEdited.State;
                    location.Latitude = locationToBeEdited.Latitude;
                    location.Longitude = locationToBeEdited.Longitude;
                    location.DistanceToCenter = locationToBeEdited.DistanceToCenter;

                    location.LocationCategoryJunctions = selectedCategoryIds.Select(s => new LocationCategoryJunction()
                    {
                        LocationId = locationToBeEdited.LocationId,
                        CategoryId = s
                    }).ToList();

                    context.SaveChanges();
                }
            }

        }

        public void AttachCategoriesToLocation(Location locationToBeEdited, int[] selectedCategoryIds)
        {
            using (var context = new BTContext())
            {
                var location = context.Locations.Include(i => i.LocationCategoryJunctions)
                                                .Where(i => i.LocationId == locationToBeEdited.LocationId)
                                                .FirstOrDefault();

                var existingCategoryIds = GetLocationWithCategoriesById(locationToBeEdited.LocationId).LocationCategoryJunctions.Select(i => i.Category.CategoryId);

                var totalCategories = selectedCategoryIds.Union(existingCategoryIds);

                if (location != null)
                {
                    location.LocationCategoryJunctions = totalCategories.Select(s => new LocationCategoryJunction()
                    {
                        LocationId = locationToBeEdited.LocationId,
                        CategoryId = s
                    }).ToList();

                    context.SaveChanges();
                }
            }

        }

        public List<Location> GetLocationsByCategoryId(int categoryId)
        {
            using (var context = new BTContext())
            {
                var locations = context.Locations.OrderByDescending(i => i.LocationId).AsQueryable();

                locations = locations.Include(i => i.LocationCategoryJunctions)
                                            .ThenInclude(i => i.Category)
                                            .Where(i => i.LocationCategoryJunctions.Any(m => m.Category.CategoryId == categoryId)
                                                                                         );

                return locations.ToList();
            }
        }

        public Location GetLocationByPlaceId(string placeId)
        {
            using(var context = new BTContext())
            {
                return context.Locations.Where(i => i.PlaceId == placeId).FirstOrDefault();
            }
        }

        public List<Location> GetAllLocationsWithCategories()
        {
            using (var context = new BTContext())
            {
                return context.Locations.Include(l => l.LocationCategoryJunctions)
                                        .ThenInclude(l => l.Category)
                                        .ToList();
            }
        }

        public List<Location> LocationListByFilters(int[] filterCategoryIds, string countryName)
        {
            using (var context = new BTContext())
            {
                var locations = context.Locations.AsQueryable();

                locations = locations.Include(i => i.LocationCategoryJunctions)
                                             .ThenInclude(i => i.Category);

                if (!string.IsNullOrWhiteSpace(countryName))
                {
                    locations = locations.Where(i => i.Country == countryName);
                }
                if (filterCategoryIds != null)
                {
                    foreach (var categoryId in filterCategoryIds)
                    {
                        locations = locations.Where(e => e.LocationCategoryJunctions.Select(s => s.Category.CategoryId).Contains(categoryId));
                    }
                }


                return locations.ToList();
            }
        }

        public object GetMarkerDisplayList()
        {
            throw new NotImplementedException();
        }
    }
}
