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
        [Route("add-user")]
        public async Task<bool> AddUserAsync(AddUserViewModel addUser) {
            User user = new User()
            {
                FisrtName = addUser.FirstName,
                Email = addUser.Email,
                LastName = addUser.LastName                
            };
            return await _userHelper.AddUserAsync(user, addUser.Password);
        }

        [HttpPost]
        [Route("login")]
        public async Task<bool> Login(LoginViewModel model) {
            if (ModelState.IsValid)
            {
                return  await _userHelper.LoginAsync(model);
            }
            return false;
        }

        public async Task Logout() => await _userHelper.LogoutAsync();
        
    }
}
