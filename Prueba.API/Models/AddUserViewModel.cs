using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Models
{
    public class AddUserViewModel
    {
     
        public string fisrtName { get; set; }

        public string lastName { get; set; }
       
        public string email { get; set; }

        public string password { get; set; } 
    }
}
