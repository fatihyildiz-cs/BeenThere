using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Business.Abstract
{
    public interface ILocationService
    {
        Location GetById(int id);

        List<Location> GetAll();

        void Create(Location entity);

        void Update(Location entity);

        void Delete(Location entity);

        Location GetLocationWithCategoriesById(int locationId);

        void Update(Location locationToBeEdited, int[] selectedCategoryIds);

        Location GetLocationWithExperiencesById(int id);

        Location GetLocationWithExperiencesAndCategoriesById(int id);

        void AttachCategoriesToLocation(Location locationToBeEdited, int[] selectedCategoryIds);

        List<Location> GetLocationsByCategoryId(int categoryId);

        Location GetLocationByPlaceId(string placeId);

        List<Location> GetAllLocationsWithCategories();

        List<Location> LocationListByFilters(int[] filterCategoryIds, string countryName);

        object GetMarkerDisplayList();
    }
}
