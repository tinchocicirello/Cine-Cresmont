using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PW3TPFinal.Models
{
    public class Usuario
    {
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public String NombreUsuario { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public String Password { get; set; }
    }
}