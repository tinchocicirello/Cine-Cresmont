using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PW3TPFinal.Models
{
    public class Cartelera
    {
        [Required(ErrorMessage = "Se debe indicar la Sede de la cartelera")]
        public int IdSede { get; set; }

        [Required(ErrorMessage = "Se debe indicar la Pelicula de la cartelera")]
        public int IdPelicula { get; set; }

        [Required(ErrorMessage = "Se debe indicar hora de inicio de cartelera")]
        [Range(15, 23, ErrorMessage = "La hora de inicio no puede ser previo a las 15hs")]
        public int HoraInicio { get; set; }

        [Required(ErrorMessage = "Se debe indicar Fecha de Inicio de cartelera")]
        public System.DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Se debe indicar Fecha de Fin de cartelera")]
        public System.DateTime FechaFin { get; set; }

        [Required]
        public int NumeroSala { get; set; }

        [Required]
        public int IdVersion { get; set; }

        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
    }
}