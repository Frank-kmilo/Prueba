using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [JsonProperty]
        public string FisrtName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [JsonProperty]
        public string LastName { get; set; }

        [JsonIgnore]
        public ICollection<TaskManagement> taskManagement { get; set; }

    }
}
