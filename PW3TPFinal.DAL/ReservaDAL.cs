using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3TPFinal.DAL
{
    public class ReservaDAL
    {
        CresmontContext ctx = new CresmontContext();


        public List<Versiones> ObtenerVersiones(int idPelicula)
        {
            var listaversiones = (from c in ctx.Carteleras where c.IdPelicula == idPelicula select c.Versiones).Distinct().ToList();

            return listaversiones;
        }

        public List<Reservas> ObtenerReservaPorFechayPelicula(DateTime finicio, DateTime ffin, int idPelicula)
        {
            return (from r in ctx.Reservas where r.IdPelicula == idPelicula && r.FechaHoraInicio >= finicio && r.FechaHoraInicio <= ffin select r).ToList();
  
        }

        //metodo para crear reserva
        public void CrearReserva(Reservas r)
        {
            ctx.Reservas.Add(r);
            ctx.SaveChanges();
        }

        public List<Reservas> ObtenerReservaPorHorario()
        {
            var horarios = (from s in ctx.Reservas select s).ToList();
            List<Reservas> listaHorarios = new List<Reservas>();
            foreach (Reservas reserva in listaHorarios)
            {
                Reservas re = new Reservas();
                re.IdReserva = reserva.IdVersion;
                re.FechaHoraInicio = reserva.FechaHoraInicio;
                listaHorarios.Add(re);
            }
            return listaHorarios;
        }

        public Versiones ObtenerVersionPorId(int id)
        {
            var queryVersiones = (from v in ctx.Versiones where v.IdVersion == id select v).FirstOrDefault();

            return queryVersiones;
        }

        public Carteleras ObtenerCarteleraPorPeliculaVersionSede(int idPelicula, int idVersion, int idSede)
        {
            return (from c in ctx.Carteleras where c.IdPelicula == idPelicula && c.IdVersion == idVersion && c.IdSede == idSede select c).FirstOrDefault();
        }

        public List<TiposDocumentos> ObtenerTiposDocumento()
        {
            return (from td in ctx.TiposDocumentos select td).ToList();
        }
    }
}
