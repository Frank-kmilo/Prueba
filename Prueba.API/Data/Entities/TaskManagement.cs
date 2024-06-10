using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba.API.Data.Entities
{
    public class TaskManagement     
    {
        public int id { get; set; }

        public User user { get; set; }

        [Display(Name = "Nombre de la tarea.")]
        [MaxLength(20, ErrorMessage ="El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio.")]
        public string name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string description { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime expirationDate { get; set; }

        [Display(Name = "Marcar como completado")]
        public bool isComplete { get; set; }
    }
}
