using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Persistence.Contexts;
using EStoreApp.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Persistence.Repositories.Concretes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<List<Product>> GetByCategoryNameAsync(string categoryName)
        {
            return await _context.Set<Product>().Where(p => p.Category.Name == categoryName).ToListAsync();
        }
    }
}
