using EStoreApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Application.Repositories.Common
{
    public interface IGenericRepository<T> where T:BaseEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task Update(T entity);
        Task Add(T entity);
        Task<bool> Delete(int id);
        Task SaveChangesAsync();
    }
}
