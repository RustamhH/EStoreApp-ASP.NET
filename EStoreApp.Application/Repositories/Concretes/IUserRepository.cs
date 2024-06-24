using EStoreApp.Application.Repositories.Common;
using EStoreApp.Domain.Entities.Concretes;

namespace EStoreApp.Application.Repositories.Concretes;

public interface IUserRepository:IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string? email);
    Task<User?> GetByEmailWithRolesAsync(string? email); // super admin Role-lara mail gonderende lazim olacaq
    Task<User?> GetByUsernameAsync(string? username);
    Task<User?> GetByTokenAsync(string? token);



}