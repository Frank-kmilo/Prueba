using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;
using Prueba.API.Models;

namespace Prueba.API.Repository
{
    public class UserRepository : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<User> _SignInManager;

        public UserRepository(UserManager<User> userManager, DataContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _SignInManager = signInManager;
        }

        public async Task<bool> AddUserAsync(User user, string password)
        {
            try
            {
                await _userManager.CreateAsync(user, password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            try
            {
                await _SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            await _SignInManager.SignOutAsync();
        }
    }
}
