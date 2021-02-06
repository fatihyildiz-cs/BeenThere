using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Data.Abstract
{
    public interface ILocationRepository: IRepository<Location>
    {
        Location GetLocationWithCategoriesById(int locationId);

        void Update(Location locationToBeEdited, int[] selectedCategoryIds);

        Location GetLocationWithExperiencesById(int id);

        void AttachCategoriesToLocation(Location locationToBeEdited, int[] selectedCategoryIds);

        Location GetLocationWithExperiencesAndCategoriesById(int id);

        List<Location> GetLocationsByCategoryId(int categoryId);

        Location GetLocationByPlaceId(string placeId);

        List<Location> GetAllLocationsWithCategories();

        List<Location> LocationListByFilters(int[] filterCategoryIds, string countryName);

        object GetMarkerDisplayList();
    }
}
