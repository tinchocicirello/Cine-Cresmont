using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PW3TPFinal.Models
{
    public class ReservaInicial
    { 
        public int IdPelicula { get; set; }

        [Required]
        public int IdVersion { get; set; }

        [Required]
        public int IdSede { get; set; }

        [Required]
        public DateTime FechaHoraInicio { get; set; }
    }
}