using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Domain.Dtos;
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
    public class UserTokenRepository : GenericRepository<UserToken>, IUserTokenRepository
    {
        public UserTokenRepository(AppDbContext context) : base(context) { }


        public async Task<UserToken> AddAsync(TokenDTO dto, User user)
        {
            var userToken = await GetByToken(dto.Token);
            if (userToken is not null)
            {
                Delete(userToken.Id);
            }

            userToken = new UserToken()
            {
                Name = dto.Name,
                Token = dto.Token,
                CreatedAt = dto.CreatedAt,
                ExpireTime = dto.ExpireTime,
                User = user,
                UserId = user.Id,
                IsDeleted = false
            };

            await _context.Set<UserToken>().AddAsync(userToken);
            await SaveChangesAsync();
            return userToken;
        }
        public async Task<UserToken?> GetByNameAsync(string tokenName)
        {
            return await _context.Set<UserToken>().FirstOrDefaultAsync(p => p.Name == tokenName);
        }

        public async Task<UserToken?> GetByToken(string token)
        {
            return await _context.Set<UserToken>().FirstOrDefaultAsync(p => p.Token == token);
        }

        public async Task<UserToken?> GetByUserIdAsync(int userId, string tokenName)
        {
            return await _context.Set<UserToken>().FirstOrDefaultAsync(p => p.Name == tokenName && p.UserId == userId);
        }
    }
}
