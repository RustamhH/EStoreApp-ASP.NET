using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Application.Services;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(AddCategoryVM addCategoryVM)
        {
            var category = new Category
            {
                Name = addCategoryVM.Name
            };
            await _categoryRepository.Add(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var result = await _categoryRepository.Delete(id);
            await _categoryRepository.SaveChangesAsync();
            return result;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return (await _categoryRepository.GetAllAsync()).ToList();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<HttpStatusCode> UpdateCategoryAsync(UpdateCategoryVM updateCategoryVM)
        {
            var category = await _categoryRepository.GetByIdAsync(updateCategoryVM.Id);
            if (category == null)
                return HttpStatusCode.NotFound;

            category.Name = updateCategoryVM.Name;
            
            await _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
