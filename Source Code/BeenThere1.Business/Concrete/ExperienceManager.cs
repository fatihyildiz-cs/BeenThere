using System;
using System.Collections.Generic;
using BeenThere1.Business.Abstract;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;

namespace BeenThere1.Business.Concrete
{
    public class ExperienceManager: IExperienceService
    {
        private readonly IExperienceRepository _ExperienceRepository;

        public ExperienceManager(IExperienceRepository experienceRepository)
        {
            _ExperienceRepository = experienceRepository;
        }

        public void AddCategoriesToExperience(Experience experienceToBeAddedCategories, int[] selectedCategoryIds)
        {
            _ExperienceRepository.AddCategoriesToExperience(experienceToBeAddedCategories,selectedCategoryIds);
        }

        public List<Experience> AllExperiencesWithCategories()
        {
            return _ExperienceRepository.AllExperiencesWithCategories();
        }

        public List<Experience> AllExperiencesWithLocations()
        {
            return _ExperienceRepository.AllExperiencesWithLocations();
        }

        public void Create(Experience entity)
        {
            _ExperienceRepository.Create(entity);
        }


        public void Delete(Experience entity)
        {
            _ExperienceRepository.Delete(entity);
        }

        public List<Experience> ExperienceListByFilters(int[] filterCategoryIds, string searchKeyWord, string countryCode, int page, int pageSize)
        {
            return _ExperienceRepository.ExperienceListByFilters(filterCategoryIds, searchKeyWord, countryCode, page, pageSize);
        }

        public List<Experience> GetAll()
        {
            return _ExperienceRepository.GetAll();
        }

        public Experience GetById(int id)
        {
            return _ExperienceRepository.GetById(id);
        }

        public List<Experience> GetExperiencesByFilter(string categoryUrl, int page, int countPerPage)
        {
            return _ExperienceRepository.GetExperiencesByFilter(categoryUrl, page, countPerPage);
        }

        public List<Experience> GetExperiencesWithCategoriesByLocationId(int id)
        {
            return _ExperienceRepository.GetExperiencesWithCategoriesByLocationId(id);
        }

        public Experience GetExperienceWithCategoriesById(int id)
        {
            return _ExperienceRepository.GetExperienceWithCategoriesById(id);
  
        }

        public int GetFilteredExperienceCount(int[] filterCategoryIds, string searchKeyWord, string countryCode)
        {
            return _ExperienceRepository.GetFilteredExperienceCount(filterCategoryIds, searchKeyWord, countryCode);
        }

        public void Update(Experience entity)
        {
            _ExperienceRepository.Update(entity);
        }

        public void Update(Experience experienceToBeEdited, int[] selectedCategoryIds)
        {
            _ExperienceRepository.Update(experienceToBeEdited, selectedCategoryIds);
        }
    }
}
