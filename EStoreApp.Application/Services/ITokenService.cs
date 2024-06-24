using EStoreApp.Domain.Dtos;
using EStoreApp.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Application.Services
{
    public interface ITokenService
    {
        string CreateAccessToken(AccessTokenDTO user);
        UserToken CreateRefreshToken();
        UserToken CreateRepasswordToken();
        UserToken CreateConfirmEmailToken();
    }
}
