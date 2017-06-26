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
        public String Email { get; set; }

        [Required(ErrorMessage = "Ingrese cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese su numero de documento")]
        [StringLength(6, ErrorMessage ="El numero debe tener 6 dígitos")]
        public int NumeroDocumento { get; set; }
    }
}