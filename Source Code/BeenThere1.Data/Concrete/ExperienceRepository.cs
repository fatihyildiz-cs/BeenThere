using System;
using System.Collections.Generic;
using System.Linq;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;
using Microsoft.EntityFrameworkCore;

namespace BeenThere1.Data.Concrete
{
    public class ExperienceRepository : GenericRepository<Experience, BTContext>, IExperienceRepository
    {

        public void AddCategoriesToExperience(Experience experienceToBeAddedCategories, int[] selectedCategoryIds)
        {
            using (var context = new BTContext())
            {
                

                var experience = context.Experiences.Include(i => i.ExperienceCategoryJunctions)
                                                .Where(i => i.ExperienceId == experienceToBeAddedCategories.ExperienceId)
                                                .FirstOrDefault();

                if (experience != null)
                {
                    experience.ExperienceCategoryJunctions = selectedCategoryIds.Select(s => new ExperienceCategoryJunction()
                    {
                        ExperienceId = experienceToBeAddedCategories.ExperienceId,
                        CategoryId = s
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        public List<Experience> AllExperiencesWithCategories()
        {
            using (var context = new BTContext())
            {
                return context.Experiences.Include(l => l.Location)
                                          .Include(l => l.ExperienceCategoryJunctions)
                                          .ThenInclude(l => l.Category)
                                          .OrderByDescending(l=> l.ExperienceId)
                                          .ToList();
            }
        }

        public List<Experience> AllExperiencesWithLocations()
        {
            using (var context = new BTContext())
            {

                return context.Experiences.Include(l=> l.Location)
                                          .ToList();
            }
        }

        public List<Experience> ExperienceListByFilters(int[] filterCategoryIds, string searchKeyWord, string countryCode, int page, int pageSize)
        {
            using(var context = new BTContext())
            {
                var experiences = context.Experiences.OrderByDescending(i => i.ExperienceId).AsQueryable();

                experiences = experiences.Include(l => l.Location)
                                             .Include(i => i.ExperienceCategoryJunctions)
                                             .ThenInclude(i => i.Category);

                if (!string.IsNullOrWhiteSpace(searchKeyWord))
                {
                    experiences = experiences.Where(i =>
                                                    i.Location.Name.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Name.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Author.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Body.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Title.ToLower().Contains(searchKeyWord.ToLower())  );
                }
                Console.WriteLine(countryCode);

                if (!string.IsNullOrWhiteSpace(countryCode))
                {
                    experiences = experiences.Where(i =>
                                                    i.Location.CountryCode.Contains(countryCode));
                }

                if (filterCategoryIds.Count() > 0)
                {
                    foreach (var categoryId in filterCategoryIds)
                    {
                        experiences = experiences.Where(e => e.ExperienceCategoryJunctions.Select(s => s.Category.CategoryId).Contains(categoryId));
                    }
                }

                
                return experiences.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }


        public List<Experience> GetExperiencesByFilter(string categoryUrl, int page, int countPerPage)
        {
            using(var context = new BTContext())
            {
                var experiences = context.Experiences.OrderByDescending(i => i.ExperienceId).AsQueryable();

                if(categoryUrl != null && categoryUrl != "")
                {
                    experiences = experiences.Include(i => i.ExperienceCategoryJunctions)
                                             .ThenInclude(i => i.Category)
                                             .Where(i => i.ExperienceCategoryJunctions.Any(m => m.Category.Url.ToLower() == categoryUrl.ToLower()));

                    
                }

                return experiences.Skip(countPerPage * (page - 1)).Take(countPerPage).ToList();
            }
        }

        public Experience GetExperienceWithCategoriesById(int id)
        {
            using (var context = new BTContext())
            {
                return context.Experiences.Where(i => i.ExperienceId == id)
                                          .Include(i => i.ExperienceCategoryJunctions)
                                          .ThenInclude(i => i.Category)
                                          .FirstOrDefault();

            }
        }

        public List<Experience> GetExperiencesWithCategoriesByLocationId(int id)
        {
            using (var context = new BTContext())
            {
                return context.Experiences.Where(i => i.LocationId == id)
                                           .OrderByDescending(i => i.DateOfCreation)
                                          .Include(i => i.Location)
                                          .Include(i => i.ExperienceCategoryJunctions)
                                          .ThenInclude(i => i.Category)
                                          .ToList();

            }
        }

        public void Update(Experience experienceToBeEdited, int[] selectedCategoryIds)
        {
            using (var context = new BTContext())
            {
                var experience = context.Experiences.Include(i => i.ExperienceCategoryJunctions)
                                                .Where(i => i.ExperienceId == experienceToBeEdited.ExperienceId)
                                                .FirstOrDefault();
                
                if (experience != null)
                {
                    experience.Name = experienceToBeEdited.Name;
                    experience.Title = experienceToBeEdited.Title;
                    experience.Body = experienceToBeEdited.Body;
                    experience.ImageUrl = experienceToBeEdited.ImageUrl;
                    experience.LocationId = experienceToBeEdited.LocationId;

                    experience.ExperienceCategoryJunctions = selectedCategoryIds.Select(s => new ExperienceCategoryJunction()
                    {
                        ExperienceId = experienceToBeEdited.ExperienceId,
                        CategoryId = s
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        public int GetFilteredExperienceCount(int[] filterCategoryIds, string searchKeyWord, string countryCode)
        {
            using (var context = new BTContext())
            {
                var experiences = context.Experiences.OrderByDescending(i => i.ExperienceId).AsQueryable();

                experiences = experiences.Include(l => l.Location)
                                             .Include(i => i.ExperienceCategoryJunctions)
                                             .ThenInclude(i => i.Category);

                if (!string.IsNullOrWhiteSpace(searchKeyWord))
                {
                    experiences = experiences.Where(i =>
                                                    i.Location.Name.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Name.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Author.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Body.ToLower().Contains(searchKeyWord.ToLower())
                                                  || i.Title.ToLower().Contains(searchKeyWord.ToLower()));
                }
                Console.WriteLine(countryCode);

                if (!string.IsNullOrWhiteSpace(countryCode))
                {
                    experiences = experiences.Where(i =>
                                                    i.Location.CountryCode.Contains(countryCode));
                }
                if (filterCategoryIds.Count() > 0)
                {
                    foreach (var categoryId in filterCategoryIds)
                    {
                        experiences = experiences.Where(e => e.ExperienceCategoryJunctions.Select(s => s.Category.CategoryId).Contains(categoryId));
                    }
                }

                return experiences.Count();
            }
        }
    }
}
