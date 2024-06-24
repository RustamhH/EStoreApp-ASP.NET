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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context) { }

        public async Task<Role?> GetRoleByRoleName(string roleName)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(p => p.Name == roleName);
        }
    }
}
