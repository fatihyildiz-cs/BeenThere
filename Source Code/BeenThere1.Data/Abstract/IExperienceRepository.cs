using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Data.Abstract
{
    public interface IExperienceRepository: IRepository<Experience>
    {

        void AddCategoriesToExperience(Experience experienceToBeAddedCategories, int[] selectedCategoryIds);

        Experience GetExperienceWithCategoriesById(int id);

        List<Experience> GetExperiencesByFilter(string categoryUrl, int page, int countPerPage);

        List<Experience> GetExperiencesWithCategoriesByLocationId(int id);

        List<Experience> ExperienceListByFilters(int[] filterCategoryIds, string searchKeyWord, string countryCode, int page, int pageSize);

        List<Experience> AllExperiencesWithCategories();

        List<Experience> AllExperiencesWithLocations();

        int GetFilteredExperienceCount(int[] filterCategoryIds, string searchKeyWord, string countryCode);

        void Update(Experience experienceToBeEdited, int[] selectedCategoryIds);
    }
}
