using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PW3TPFinal.Models
{
    public class Sede
    {
        [Required(ErrorMessage = "Debe ingresar un nombre de sede")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una direccion de sede")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un precio de entrada general")]
        public decimal PrecioGeneral { get; set; }
    }
}