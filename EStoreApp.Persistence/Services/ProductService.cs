using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Application.Services;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Category;
using EStoreApp.Persistence.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Persistence.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task AddProductAsync(AddProductVM addProductVM)
        {
            var product = new Product
            {
                Name = addProductVM.Name,
                Description=addProductVM.Description,
                CategoryId=addProductVM.CategoryId,
                Price= addProductVM.Price,
            };
            await _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await _productRepository.Delete(id);
            await _productRepository.SaveChangesAsync();
            return result;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return (await _productRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Product>> GetProductByCategoryName(string categoryName)
        {
            return await _productRepository.GetByCategoryNameAsync(categoryName);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<HttpStatusCode> UpdateProductAsync(UpdateProductVM updateProductVM)
        {
            var category = await _productRepository.GetByIdAsync(updateProductVM.Id);
            if (category == null)
                return HttpStatusCode.NotFound;

            category.Name = updateProductVM.Name;

            await _productRepository.Update(category);
            await _productRepository.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
