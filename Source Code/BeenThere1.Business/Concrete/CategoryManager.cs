using System;
using System.Collections.Generic;
using BeenThere1.Business.Abstract;
using BeenThere1.Data.Abstract;
using BeenThere1.Entity;

namespace BeenThere1.Business.Concrete
{
    public class CategoryManager: ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            _CategoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _CategoryRepository.Delete(entity);
        }

        public void DeleteLocationFromCategory(int locationId, int categoryId)
        {
            _CategoryRepository.DeleteLocationFromCategory(locationId,categoryId);
        }

        //public void DeleteFromCategory(int productId, int categoryId)
        //{
        //    _CategoryRepository.DeleteFromCategory(productId, categoryId);
        //}

        public List<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _CategoryRepository.GetById(id);
        }

        public Category GetByUrl(string url)
        {
            return _CategoryRepository.GetByUrl(url);
        }

        public Category GetCategoryWithLocationsById(int categoryId)
        {
            return _CategoryRepository.GetCategoryWithLocationsById(categoryId);
        }

        //public Category GetByIdWithProducts(int categoryId)
        //{
        //    return _CategoryRepository.GetByIdWithProducts(categoryId);
        //}

        public void Update(Category entity)
        {
            _CategoryRepository.Update(entity);
        }
    }
}
