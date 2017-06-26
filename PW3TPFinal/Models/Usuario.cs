using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PW3TPFinal.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Ingrese nombre de usuario")]
        public String NombreUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese un password")]
        public String Password { get; set; }
    }
}