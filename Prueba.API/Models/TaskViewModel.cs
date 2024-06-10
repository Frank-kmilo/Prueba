using Prueba.API.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Nombre de la tarea.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Marcar como completado")]
        public bool IsComplete { get; set; }
    }
}
