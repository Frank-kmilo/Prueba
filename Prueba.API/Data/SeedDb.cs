using Prueba.API.Data.Entities;
using Prueba.API.Helpers;
using SQLitePCL;

namespace Prueba.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _contet;
        private readonly IUserHelper _Userhelper;

        public SeedDb(DataContext contet, IUserHelper userhelper)
        {
            _contet = contet;
            _Userhelper = userhelper;
        }

        public IUserHelper Userhelper { get; }

        public async Task SeedAsync()
        {
            await _contet.Database.EnsureCreatedAsync();
            await ChecUserAsync("Usuario", "Prueba", "usuario@yopmail.com");
        }

        private async Task ChecUserAsync(string firstName, string lastName, string email)
        {
            User user = await _Userhelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    fisrtName = firstName,
                    lastName = lastName,
                    UserName = email
                };

                await _Userhelper.AddUserAsync(user, "1234");
            }
        }
    }
}
