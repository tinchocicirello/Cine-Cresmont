using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PW3TPFinal.DAL;

namespace PW3TPFinal.logica
{
    public class ReservaService
    {
        ReservaDAL rdal = new ReservaDAL();

        // metodo para obtener las versiones
        public List<Versiones> ObtenerVersiones()
        {
            List<Versiones> listaVersiones = rdal.ObtenerVersiones();
            return listaVersiones;
        }

        // metodo para obtener reserva por fecha
        public List<Reservas> ObtenerReservaPorFecha()
        {
            List<Reservas> listaReservaFecha = rdal.ObtenerReservaPorFecha();
            return listaReservaFecha;
        }

        // metodo para obtener reservas por Hora
        public List<Reservas> ObtenerReservaPorHorario()
        {
            List<Reservas> listaReservaHora = rdal.ObtenerReservaPorHorario();
            return listaReservaHora;
        }


        // metodo para obtener version por id
        public Versiones ObtenerVersion(int idVersion)
        {
            Versiones version = new Versiones();
            version = rdal.ObtenerVersion(idVersion);

            return version;
        }
    }
}
