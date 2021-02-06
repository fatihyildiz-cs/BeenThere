using System;
using BeenThere1.Entity;

namespace BeenThere1.Data.Abstract
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Category GetCategoryWithLocationsById(int categoryId);

        void DeleteLocationFromCategory(int locationId, int categoryId);

        Category GetByUrl(string url);
    }
}
