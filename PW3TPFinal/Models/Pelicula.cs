using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PW3TPFinal.Models
{
    public class Pelicula
    {
        [Required(ErrorMessage = "Debe ingresar un nombre de pelicula")]
        [StringLength(30, MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripcion de pelicula")]
        [StringLength(500, MinimumLength = 10)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar una imagen de pelicula")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "Debe ingresar una duracion de pelicula")]
        [Range(30, 90, ErrorMessage = "La duracion debe ser de máximo 90 minutos y minimo 30 minutos")]
        public int Duracion { get; set; }


        public int IdCalificacion { get; set; }


        public int IdGenero { get; set; }

    }
}