using Microsoft.AspNetCore.Mvc;
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
