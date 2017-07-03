using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PW3TPFinal.DAL;

namespace PW3TPFinal.logica
{
    public class CarteleraService
    {
        CarteleraDAL cdal = new CarteleraDAL();

        //metodo para guardar nuevas las carteleras
        public void AgregarCartelera(Carteleras c)
        {
            cdal.AgregarCartelera(c);
            return;
        }


        // metodo para borrar las carteleras
        public void BorrarCartelera(int idCartelera)
        {
            cdal.BorrarCartelera(idCartelera);
            return;

        }

        // metodo para editar las carteleras
        public void EditarCartelera(Carteleras c)
        {
            cdal.EditarCartelera(c);
            return;

        }


        // metodo para obtener lista de carteleras
        public List<Carteleras> ObtenerCarteleras()
        {
            List<Carteleras> listaCarteleras = cdal.ObtenerCarteleras();
            return listaCarteleras;
        }

        // metodo para obtener cartelera por id
        public Carteleras ObtenerCartelerasPorId(int idCartelera)
        {
            Carteleras c = cdal.ObtenerCartelerasPorId(idCartelera);
            return c;
        }


        // metodo para obtener carteleras por sede
        public List<Carteleras> ObtenerCarteleraPorSede(int sede)
        {
            List<Carteleras> listaCartelerasSede = cdal.ObtenerCarteleraPorSede(sede);
            return listaCartelerasSede;
        }

        // metodo para obtener sedes por carteleras
        public List<Sedes> ObtenerSedesPorPelicula(int idPelicula, int idVersion)
        {
            List<Sedes> listaSedes = cdal.ObtenerSedesPorPelicula(idPelicula,idVersion);
            return listaSedes;
        }

        // metodo para obtener ids sede de las carteleras
        public List<int> ObtenerIdSedesPorCartelera()
        {
            List<int> idSedes = cdal.ObtenerIdSedesPorCartelera();
            return idSedes;
        }

        // obtengo una lista de sedes disponibles para crear carteleras
        public List<Sedes> ObtenerSedesDisponiblesCarteleras()
        {
            List<Sedes> listaSedesDispo = cdal.ObtenerSedesDisponiblesCarteleras();
            return listaSedesDispo;
        }
    }
}
