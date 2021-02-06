using System;
using System.Collections.Generic;
using BeenThere1.Entity;

namespace BeenThere1.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);

        void Delete(Category entity);

        Category GetCategoryWithLocationsById(int categoryId);

        void DeleteLocationFromCategory(int locationId, int categoryId);

        Category GetByUrl(string url);
    }
}
