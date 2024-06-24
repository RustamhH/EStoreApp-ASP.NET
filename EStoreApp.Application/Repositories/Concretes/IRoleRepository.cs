using EStoreApp.Application.Repositories.Common;
using EStoreApp.Domain.Entities.Concretes;

namespace EStoreApp.Application.Repositories.Concretes;

public interface IRoleRepository:IGenericRepository<Role>
{
    Task<Role?> GetRoleByRoleName(string roleName);
}
