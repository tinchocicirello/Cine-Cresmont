using PW3TPFinal.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3TPFinal.DAL
{
    public class CarteleraDAL
    {
        private CresmontContext ctx = new CresmontContext();


        //metodo para guardar nuevas las carteleras
        public void AgregarCartelera(Carteleras c)
        {
            ctx.Carteleras.Add(c);
            ctx.SaveChanges();
        }


        // metodo para borrar las carteleras
        public void BorrarCartelera(int id)
        {
            var queryBorrar = from c in ctx.Carteleras where c.IdCartelera == id select c;

            foreach (var cartelera in queryBorrar)
            {
                ctx.Carteleras.Remove(cartelera);
            }
            ctx.SaveChanges();

        }

        // metodo para obtener cartelera por id
        public Carteleras ObtenerCartelerasPorId(int idCartelera)
        {
            var cartId = from ca in ctx.Carteleras where ca.IdCartelera == idCartelera select ca;

            Carteleras c = new Carteleras();

            foreach(Carteleras cartelera in cartId)
            {
                c.IdCartelera = cartelera.IdCartelera;
                c.IdSede = cartelera.IdSede;
                c.IdVersion = cartelera.IdVersion;
                c.Lunes = cartelera.Lunes;
                c.Martes = cartelera.Martes;
                c.Miercoles = cartelera.Miercoles;
                c.Jueves = cartelera.Jueves;
                c.Viernes = cartelera.Viernes;
                c.Sabado = cartelera.Sabado;
                c.Domingo = cartelera.Domingo;
                c.FechaInicio = cartelera.FechaInicio;
                c.FechaFin = cartelera.FechaFin;
                c.HoraInicio = cartelera.HoraInicio;
                c.NumeroSala = cartelera.NumeroSala;
                c.IdPelicula = cartelera.IdPelicula;

            }
            return c;
        }


        // metodo para editar las carteleras
        public void EditarCartelera(Carteleras cartelera)
        {
            var editarCartelera = from c in ctx.Carteleras where c.IdCartelera == cartelera.IdCartelera select c;

            foreach (Carteleras c in editarCartelera)
            {
                c.IdSede = cartelera.IdSede;
                c.IdVersion = cartelera.IdVersion;
                c.Lunes = cartelera.Lunes;
                c.Martes = cartelera.Martes;
                c.Miercoles = cartelera.Miercoles;
                c.Jueves = cartelera.Jueves;
                c.Viernes = cartelera.Viernes;
                c.Sabado = cartelera.Sabado;
                c.Domingo = cartelera.Domingo;
                c.FechaInicio = cartelera.FechaInicio;
                c.FechaFin = cartelera.FechaFin;
                c.HoraInicio = cartelera.HoraInicio;
                c.NumeroSala = cartelera.NumeroSala;
                c.IdPelicula = cartelera.IdPelicula;
            }

            ctx.SaveChanges();

        }

        // metodo para obtener lista de carteleras
        public List<Carteleras> ObtenerCarteleras()
        {
            var queryCarteleras = (from c in ctx.Carteleras select c).ToList();

            return queryCarteleras;
        }


        // metodo para obtener carteleras por sede
        public List<Carteleras> ObtenerCarteleraPorSede(int sede)
        {
            var querySede = (from c in ctx.Carteleras where c.IdSede == sede select c).ToList();
            return querySede;
        }

        // metodo para obtener sedes por carteleras
        public List<Sedes> ObtenerSedesPorPelicula(int idPelicula, int idVersion)
        {
            var listaSedes = (from c in ctx.Carteleras where c.IdPelicula == idPelicula && c.IdVersion == idVersion select c.Sedes).ToList();
            return listaSedes;
        }

        // metodo para obtener ids sede de las carteleras
        public List<int> ObtenerIdSedesPorCartelera()
        {
            var sedesCarteleras = (from c in ctx.Carteleras select c.Sedes.IdSede).ToList();
            return sedesCarteleras;
        }

        // obtengo una lista de sedes disponibles para crear carteleras
        public List<Sedes> ObtenerSedesDisponiblesCarteleras()
        {
            var listaSedes = (from s in ctx.Sedes where  !(from c in ctx.Carteleras select c.Sedes.IdSede).Contains(s.IdSede) select s).ToList();
            return listaSedes;
        }

        // obtengo una lista de sedes disponibles para editar carteleras
        public List<Sedes> ObtenerSedesDisponiblesCartelerasMenosActual(int idCartelera)
        {
            var listaSedes = (from s in ctx.Sedes where !(from c in ctx.Carteleras where c.IdCartelera != idCartelera  select c.Sedes.IdSede).Contains(s.IdSede) select s).ToList();
            return listaSedes;
        }

    }
}

