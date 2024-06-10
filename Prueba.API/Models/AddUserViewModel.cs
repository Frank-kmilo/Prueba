using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Models
{
    public class AddUserViewModel
    {     
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public string Email { get; set; }

        public string Password { get; set; } 
    }
}
