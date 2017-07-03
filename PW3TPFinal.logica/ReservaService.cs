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
        public List<Versiones> ObtenerVersiones(int idPelicula)
        {
            List<Versiones> listaVersiones = rdal.ObtenerVersiones(idPelicula);
            return listaVersiones;
        }

        // metodo para obtener reserva por fecha
        public List<Reservas> ObtenerReservaPorFechayPelicula(DateTime finicio, DateTime ffin, int idPelicula)
        {
           return rdal.ObtenerReservaPorFechayPelicula(finicio,ffin,idPelicula);
        }

        // metodo para obtener reservas por Hora
        public List<Reservas> ObtenerReservaPorHorario()
        {
            List<Reservas> listaReservaHora = rdal.ObtenerReservaPorHorario();
            return listaReservaHora;
        }

        //metodo para crear reserva
        public void CrearReserva(Reservas r)
        {
            rdal.CrearReserva(r);
            return;
        }

        // metodo para obtener version por id
        public Versiones ObtenerVersionPorId(int idVersion)
        {
            Versiones version = new Versiones();
            version = rdal.ObtenerVersionPorId(idVersion);

            return version;
        }

        public Carteleras ObtenerCarteleraPorPeliculaVersionSede(int idPelicula, int idVersion, int idSede)
        {
            return rdal.ObtenerCarteleraPorPeliculaVersionSede(idPelicula, idVersion, idSede);
        }

        public List<TiposDocumentos> ObtenerTiposDocumento()
        {
            return rdal.ObtenerTiposDocumento();

        }
    }
}
