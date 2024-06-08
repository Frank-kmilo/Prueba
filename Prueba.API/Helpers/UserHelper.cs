using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Data.Entities;

namespace Prueba.API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public UserHelper(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public DataContext Context { get; }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
