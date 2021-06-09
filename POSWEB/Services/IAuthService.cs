using Domain.Entities;
using System;
using System.Threading.Tasks;
using WebUI.DTO;

namespace WebUI.Services
{
    public interface IAuthService
    {
        string GetAccessToken(User user, Guid identifier);
        Task<string> GetAccessTokenAsync(UserCredDTO data);
        Task InsertUserToken(Guid userId, Guid token);
    }
}