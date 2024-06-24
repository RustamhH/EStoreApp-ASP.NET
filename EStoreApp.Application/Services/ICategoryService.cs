using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Application.Services
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(AddCategoryVM addCategoryRequestDTO);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<HttpStatusCode> UpdateCategoryAsync(UpdateCategoryVM updateCategoryRequestDTO);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
