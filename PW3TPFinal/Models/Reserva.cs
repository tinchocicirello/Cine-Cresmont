using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PW3TPFinal.Models
{
    public partial class Reserva
    {
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Ingrese un email válido")]
        [Required(ErrorMessage = "Ingrese un email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar un tipo de documento")]
        public int IdTipoDocumento { get; set; }

        [Required(ErrorMessage = "Ingrese su numero de documento")]
        [StringLength(8, ErrorMessage ="El numero debe tener 8 dígitos")]
        public string NumeroDocumento { get; set; }
    }
}