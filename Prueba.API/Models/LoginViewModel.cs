using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes ingresar un Emlail Válido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string userName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Constraseña")]
        [MaxLength(4, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string password { get; set; }
    }
}
