using System;
using System.Linq;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;
using Microsoft.EntityFrameworkCore;

namespace BeenThere1.Data.Concrete
{
    public class CategoryRepository : GenericRepository<Category, BTContext>, ICategoryRepository
    {
        public void DeleteLocationFromCategory(int locationId, int categoryId)
        {
            using (var context = new BTContext())
            {
                var command = "delete from locationcategoryjunction where LocationID = @p0 and CategoryId = @p1";
                context.Database.ExecuteSqlRaw(command, locationId, categoryId);
            }
        }

        public Category GetByUrl(string url)
        {
            using (var context = new BTContext())
            {
                return context.Categories.Where(c => c.Url == url).FirstOrDefault();
                                         
            }
        }

        public Category GetCategoryWithLocationsById(int categoryId)
        {
            using(var context = new BTContext())
            {
                return context.Categories.Where(c => c.CategoryId == categoryId)
                                         .Include(c => c.LocationCategoryJunctions)
                                         .ThenInclude(c => c.Location)
                                         .FirstOrDefault();
            }
            
        }
    }
}
