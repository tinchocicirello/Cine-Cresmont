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


        // metodo para obtener lista de carteleras
        public List<Carteleras> ObtenerCarteleras()
        {
            List<Carteleras> listaCarteleras = cdal.ObtenerCarteleras();
            return listaCarteleras;
        }


        // metodo para obtener carteleras por sede
        public List<Carteleras> ObtenerCarteleraPorSede(int sede)
        {
            List<Carteleras> listaCartelerasSede = cdal.ObtenerCarteleraPorSede(sede);
            return listaCartelerasSede;
        }
    }
}
