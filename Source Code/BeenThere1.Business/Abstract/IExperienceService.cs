using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Business.Abstract
{
    public interface IExperienceService
    {
        Experience GetById(int id);

        List<Experience> GetAll();

        void Create(Experience entity);

        void Update(Experience entity);

        void Delete(Experience entity);

        void Update(Experience experienceToBeEdited, int[] selectedCategoryIds);

        void AddCategoriesToExperience(Experience experienceToBeAddedCategories, int[] selectedCategoryIds);

        Experience GetExperienceWithCategoriesById(int id);

        List<Experience> GetExperiencesByFilter(string categoryUrl, int page, int countPerPage);

        List<Experience> ExperienceListByFilters(int[] filterCategoryIds, string searchKeyWord, string countryCode, int page, int pageSize);

        List<Experience> GetExperiencesWithCategoriesByLocationId(int id);

        List<Experience> AllExperiencesWithCategories();

        List<Experience> AllExperiencesWithLocations();

        int GetFilteredExperienceCount(int[] filterCategoryIds, string searchKeyWord, string countryCode);
    }
}
