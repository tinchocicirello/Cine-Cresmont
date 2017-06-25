using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PW3TPFinal.DAL;

namespace PW3TPFinal.logica
{
    public class PeliculaService
    {
        PeliculaDAL pdal = new PeliculaDAL();

        // Metodo para agregar nueva pelicula
        public void AgregarPelicula(Peliculas p)
        {
            pdal.AgregarPelicula(p);
        }

        // metodo para listar peliculas
        public List<Peliculas> ObtenerPeliculas()
        {
            List<Peliculas> listaPelis = pdal.ObtenerPeliculas();

            return listaPelis;
        }

        // metodo para actualizar una pelicula
        public void ActualizarPelicula(Peliculas p)
        {
            pdal.ActualizarPelicula(p);
            return;

        }


        // metodo para obtener peliculas por id
        public Peliculas ObtenerPeliculaPorId(int idPelicula)
        {
            Peliculas pelicula = new Peliculas();
            pelicula = pdal.ObtenerPeliculaPorId(idPelicula);

            return pelicula;
            
        }


        // metodo para listar generos
        public List<Generos> ObtenerGeneros()
        {
            List<Generos> listaGeneros = pdal.ObtenerGeneros();

            return listaGeneros;
        }


        // metodo para listar claificaciones
        public List<Calificaciones> ObtenerCalificaciones()
        {
            List<Calificaciones> listaCalif = pdal.ObtenerCalificaciones();
            return listaCalif;
        }

        // metodo para listar las versiones
        public List<Versiones> ObtenerVersiones()
        {
            List<Versiones> listaVersiones = pdal.ObtenerVersiones(); 

            return listaVersiones;
        }



    }
}
