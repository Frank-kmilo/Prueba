using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;
using Prueba.API.Models;

namespace Prueba.API.Controllers
{
    [Produces("aplication/json")]
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper;
        }      

        [HttpPost]
        [Route("add-user-Async")]
        public async Task<IdentityResult> AddUserAsync(AddUserViewModel addUser) {
            User user = new User()
            {
                fisrtName = addUser.fisrtName,
                Email = addUser.email,
                lastName = addUser.lastName,
            };
            return await _userHelper.AddUserAsync(user, addUser.password);
        }

        [HttpPost]
        [Route("login")]
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
