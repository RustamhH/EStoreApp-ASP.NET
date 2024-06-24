using EStoreApp.Application.Repositories.Common;
using EStoreApp.Domain.Dtos;
using EStoreApp.Domain.Entities.Concretes;

namespace EStoreApp.Application.Repositories.Concretes;

public interface IUserTokenRepository : IGenericRepository<UserToken>
{
    Task<UserToken> AddAsync(TokenDTO dto, User user);
    Task<UserToken?> GetByNameAsync(string tokenName);
    Task<UserToken?> GetByToken(string token);
    Task<UserToken?> GetByUserIdAsync(int userId, string tokenName);
}
