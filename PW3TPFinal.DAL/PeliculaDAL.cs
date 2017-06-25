using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PW3TPFinal.DAL.Repositorios;

namespace PW3TPFinal.DAL
{
    public class PeliculaDAL
    {
        CresmontContext ctx = new CresmontContext();

        // Metodo para agregar nueva pelicula 
        public void AgregarPelicula(Peliculas p)
        {
            CresmontContext contexto = new CresmontContext();

            contexto.Peliculas.Add(p);
            contexto.SaveChanges();
        }

        // metodo para listar peliculas
        public List<Peliculas> ObtenerPeliculas()
        {
            var queryPeliculas = (from p in ctx.Peliculas select p).ToList();
            return queryPeliculas;
        }

        // metodo para actualizar una pelicula
        public void ActualizarPelicula(Peliculas peli)
        {
            var queryPeli = from p in ctx.Peliculas where p.IdPelicula == peli.IdPelicula select p;


            foreach (Peliculas p in queryPeli)
            {
                p.Nombre = peli.Nombre;
                p.Descripcion = peli.Descripcion;
                p.IdGenero = peli.IdGenero;
                p.Duracion = peli.Duracion;
                p.Imagen = peli.Imagen;
                p.IdCalificacion = peli.IdCalificacion;
            }

            ctx.SaveChanges();

        }


        // metodo para obtener peliculas por id
        public Peliculas ObtenerPeliculaPorId(int idPeli)
        {
            var queryPeliId = from p in ctx.Peliculas where p.IdPelicula == idPeli select p;

            Peliculas peli = new Peliculas();

            foreach (Peliculas p in queryPeliId)
            {
                peli.IdPelicula = p.IdPelicula;
                peli.Nombre = p.Nombre;
                peli.Descripcion = p.Descripcion;
                peli.Imagen = p.Imagen;
                peli.IdCalificacion = p.IdCalificacion;
                peli.IdGenero = p.IdGenero;
                peli.Duracion = p.Duracion;
            }
            return peli;
        }


        // metodo para listar generos
        public List<Generos> ObtenerGeneros()
        {
            var queryGeneros = (from g in ctx.Generos select g).ToList();

            List<Generos> generoList = new List<Generos>();
            Generos genero = new Generos();

            foreach (Generos g in queryGeneros)
            {
                genero.IdGenero = g.IdGenero;
                genero.Nombre = g.Nombre;
                generoList.Add(genero);
            }

            return generoList;
        }


        // metodo para listar claificaciones
        public List<Calificaciones> ObtenerCalificaciones()
        {
            var queryCalif = (from c in ctx.Calificaciones select c).ToList();

            List<Calificaciones> calificacionesList = new List<Calificaciones>();
            Calificaciones calificacion = new Calificaciones();

            foreach (Calificaciones c in queryCalif)
            {
                
                calificacion.IdCalificacion = c.IdCalificacion;
                calificacion.Nombre = c.Nombre;
                calificacionesList.Add(calificacion);
            }

            return calificacionesList;
        }

        // metodo para listar las versiones
        public List<Versiones> ObtenerVersiones()
        {
            var versiones = (from v in ctx.Versiones select v).ToList();

            return versiones;
        }
    }
}
