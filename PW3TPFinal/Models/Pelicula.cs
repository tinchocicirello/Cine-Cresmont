using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PW3TPFinal.Models
{
    public class Pelicula
    {
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string Descripcion { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        [Range(30, 90, ErrorMessage = "La duracion debe ser de máximo 90 minutos y minimo 30 minutos")]
        public int Duracion { get; set; }

    }
}