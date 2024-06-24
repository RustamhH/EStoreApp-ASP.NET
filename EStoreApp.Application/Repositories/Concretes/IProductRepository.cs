using EStoreApp.Application.Repositories.Common;
using EStoreApp.Domain.Entities.Concretes;
using System.Collections.Generic;

namespace EStoreApp.Application.Repositories.Concretes;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<List<Product>> GetByCategoryNameAsync(string categoryName);
}