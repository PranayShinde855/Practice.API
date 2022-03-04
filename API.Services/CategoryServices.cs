using API.Database.Repository;
using API.Model;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICategoryServices
    {
        Category AddCategory(Category category);

        Task<IEnumerable> GetAllCatgeories();

        Task<Category> GetCategoryId(int Id);

        Task<Category> UpdateCategroy(Category category);

        Task<bool> DeleteCategory(int Id);
    }

    public class CategoryServices : ICategoryServices
    {
        protected ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category AddCategory(Category category)
        {
            _categoryRepository.Add(category);
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var searchCategory = _categoryRepository.GetById(id);
            if(searchCategory != null)
            {
                _categoryRepository.Delete(await searchCategory);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable> GetAllCatgeories()
        {
            return await _categoryRepository.Get();
        }
        public async Task<Category> GetCategoryId(int Id)
        {
            return await _categoryRepository.GetById(Id);
        }
       public async Task<Category> UpdateCategroy(Category category)
        {
            Category searchCategory = await GetCategoryId(category.Id);
            if (searchCategory != null)
            {
                searchCategory.CategoryName = category.CategoryName;
                searchCategory.ModifiedDate = DateTime.Now;
                _categoryRepository.Update(searchCategory);
                return category;
            }
            return searchCategory;
        }
    }
}
