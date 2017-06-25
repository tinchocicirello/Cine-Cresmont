using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PW3TPFinal.DAL.Repositorios
{
    public class RepositorioManager
    {
        public SedeRepositorio Sedes { get; set; }
        public PeliculaRepositorio Peliculas { get; set; }
        public ReservaRepositorio Reservas { get; set; }
        public CarteleraRepositorio Carteleras { get; set; }
        public CalificacionRepositorio Calificaciones { get; set; }
        public GeneroRepositorio Generos { get; set; }
        public VersionRepositorio Versiones { get; set; }

        public RepositorioManager()
        {
            var ctx = new CresmontContext();
            Peliculas = new PeliculaRepositorio(ctx);
            Sedes = new SedeRepositorio(ctx);
            Reservas = new ReservaRepositorio(ctx);
            Carteleras = new CarteleraRepositorio(ctx);
            Generos = new GeneroRepositorio(ctx);
            Versiones = new VersionRepositorio(ctx);
            Calificaciones = new CalificacionRepositorio(ctx);

        }
    }
}