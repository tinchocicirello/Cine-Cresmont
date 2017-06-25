using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PW3TPFinal.Models
{
    public class Cartelera
    {
        public int IdCartelera { get; set; }
        public string Sede { get; set; }
        public int Sala { get; set; }
        public string Pelicula { get; set; }
        public string Version { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
    }
}