using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PW3TPFinal.DAL;


namespace PW3TPFinal.logica
{
    public class SedeService
    {
        SedeDAL sdal = new SedeDAL();

        //metodo para guardad las sedes
        public void GuardarSede(Sedes sede)
        {

            sdal.GuardarSede(sede);
            return;
        }

        //metodo para actualizar una sede
        public void ActualizarSede(Sedes sede)
        {
            sdal.ActualizarSede(sede);
            return;

        }


        // metodo para listar las sedes
        public List<Sedes> ObtenerSedes()
        {
            List<Sedes> listaSedes = sdal.ObtenerSedes();
            return listaSedes;
        }


        // metodo para obtener sedes por id
        public Sedes ObtenerSedePorId(int idSede)
        {
            Sedes sede = sdal.ObtenerSedePorId(idSede);
            return sede;
        }
    }
}
