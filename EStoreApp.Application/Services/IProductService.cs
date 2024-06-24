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
    public interface IProductService
    {
        Task AddProductAsync(AddProductVM addProductRequestDTO);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductByCategoryName(string categoryName);
        Task<HttpStatusCode> UpdateProductAsync(UpdateProductVM updateProductRequestDTO);
        Task<bool> DeleteProductAsync(int id);
    }
}
