using Microsoft.AspNetCore.Identity;
using Prueba.API.Data.Entities;
using Prueba.API.Models;

namespace Prueba.API.Helpers
{
    public interface IUserHelper
    {                
        Task<User> GetUserAsync(string email);
        Task<bool> AddUserAsync(User user, string password);
        Task<bool> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }
}
