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


        public List<Versiones> ObtenerVersiones()
        {
            var versiones = (from v in ctx.Versiones select v).ToList();
            List<Versiones> listaversiones = new List<Versiones>();

            foreach (Versiones version in listaversiones)
            {
                Versiones ver = new Versiones();
                ver.IdVersion = version.IdVersion;
                ver.Nombre = version.Nombre;
                listaversiones.Add(ver);
            }

            return listaversiones;
        }

        public List<Reservas> ObtenerReservaPorFecha()
        {
            var dias = (from s in ctx.Reservas select s).ToList();
            List<Reservas> listaDias = new List<Reservas>();
            foreach (Reservas reserva in listaDias)
            {
                Reservas re = new Reservas();
                re.IdReserva = reserva.IdVersion;
                re.FechaCarga = reserva.FechaCarga;
                listaDias.Add(re);
            }
            return listaDias;
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
            var queryVersiones = (from v in ctx.Versiones where v.IdVersion == id select v).ToList();

            Versiones version = new Versiones();

            foreach (Versiones ver in queryVersiones)
            {
                version.IdVersion = ver.IdVersion;
                version.Nombre = ver.Nombre;
            }
            return version;
        }
    }
}
