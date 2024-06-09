using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Models
{
    public class AddUserViewModel
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

        [Display(Name = "Email")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [JsonProperty]
        public string Email { get; set; }
    }
}
