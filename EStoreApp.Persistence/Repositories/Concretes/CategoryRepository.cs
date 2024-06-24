using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Persistence.Contexts;
using EStoreApp.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Persistence.Repositories.Concretes
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

    }
}
