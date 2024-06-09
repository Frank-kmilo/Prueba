using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;
using Prueba.API.Models;

namespace Prueba.API.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }      

        [HttpPost]
        [Route("Account/AddUserAsync")]
        public async Task<IdentityResult> AddUserAsync(AddUserViewModel addUser, string password) {
            User user = new User()
            {
                FisrtName = addUser.FisrtName,
                Email = addUser.Email,
                LastName = addUser.LastName,
            };
            return await _userHelper.AddUserAsync(user, password);
        }

        [HttpPost]
        [Route("Account/Login")]
        public async Task<bool> Login(LoginViewModel model) {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                return result.Succeeded;
            }
            return false;
        }

        public async Task Logout() { 
        await _userHelper.LogoutAsync();
        }
    }
}
