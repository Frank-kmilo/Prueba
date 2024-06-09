using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Models;

namespace Prueba.API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;
        private readonly SignInManager<User> _SignInManager;

        public UserHelper(UserManager<User> userManager, DataContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _SignInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _SignInManager.SignOutAsync();
        }
    }
}
