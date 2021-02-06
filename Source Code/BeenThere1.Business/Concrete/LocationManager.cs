using System;
using System.Collections.Generic;
using BeenThere1.Business.Abstract;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;

namespace BeenThere1.Business.Concrete
{
    public class LocationManager: ILocationService
    {
        private readonly ILocationRepository _LocationRepository;

        public LocationManager(ILocationRepository locationRepository)
        {
            _LocationRepository = locationRepository;
        }

        public void AttachCategoriesToLocation(Location locationToBeEdited, int[] selectedCategoryIds)
        {
            _LocationRepository.AttachCategoriesToLocation(locationToBeEdited, selectedCategoryIds);
        }

        public void Create(Location entity)
        {
            _LocationRepository.Create(entity);
        }

        public void Delete(Location entity)
        {
            _LocationRepository.Delete(entity);
        }

        public List<Location> GetAll()
        {
            return _LocationRepository.GetAll();
        }

        public List<Location> GetAllLocationsWithCategories()
        {
            return _LocationRepository.GetAllLocationsWithCategories();
        }

        public Location GetById(int id)
        {
            return _LocationRepository.GetById(id);
        }

        public Location GetLocationByPlaceId(string placeId)
        {
            return _LocationRepository.GetLocationByPlaceId(placeId);
        }

        public List<Location> GetLocationsByCategoryId(int categoryId)
        {
            return _LocationRepository.GetLocationsByCategoryId(categoryId);
        }

        public Location GetLocationWithCategoriesById(int locationId)
        {
            return _LocationRepository.GetLocationWithCategoriesById(locationId);
        }

        public Location GetLocationWithExperiencesAndCategoriesById(int id)
        {
            return _LocationRepository.GetLocationWithExperiencesAndCategoriesById(id);
        }

        public Location GetLocationWithExperiencesById(int id)
        {
            return _LocationRepository.GetLocationWithExperiencesById(id);
        }

        public object GetMarkerDisplayList()
        {
            return _LocationRepository.GetMarkerDisplayList();
        }

        public List<Location> LocationListByFilters(int[] filterCategoryIds, string countryName)
        {
            return _LocationRepository.LocationListByFilters(filterCategoryIds, countryName);
        }

        public void Update(Location entity)
        {
            _LocationRepository.Update(entity);
        }

        public void Update(Location locationToBeEdited, int[] selectedCategoryIds)
        {
            _LocationRepository.Update(locationToBeEdited,selectedCategoryIds);
        }
    }
}
