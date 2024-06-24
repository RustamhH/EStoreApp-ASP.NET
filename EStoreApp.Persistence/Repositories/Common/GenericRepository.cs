using EStoreApp.Application.Repositories.Common;
using EStoreApp.Domain.Entities.Common;
using EStoreApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context=context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            entity.CreatedDate = DateTime.UtcNow;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.UtcNow;
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(p=>p.IsDeleted==false).ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            entity.UpdatedDate = DateTime.UtcNow;
        }

    }
}
