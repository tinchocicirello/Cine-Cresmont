using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW3TPFinal.DAL
{
    public class SedeDAL
    {
        CresmontContext ctx = new CresmontContext();

        //metodo para guardad las sedes
        public void GuardarSede(Sedes sede)
        {
            ctx.Sedes.Add(sede);
            ctx.SaveChanges();
        }

        //metodo para actualizar una sede
        public void ActualizarSede(Sedes sede)
        {
            var querySede = from s in ctx.Sedes where s.IdSede == sede.IdSede select s;

            foreach (Sedes s in querySede)
            {
                s.Nombre = sede.Nombre;
                s.Direccion = sede.Direccion;
                s.PrecioGeneral = sede.PrecioGeneral;
            }

            ctx.SaveChanges();

        }


        // metodo para listar las sedes
        public List<Sedes> ObtenerSedes()
        {
            var querySedes = (from s in ctx.Sedes select s).ToList();
            return querySedes;
        }


        // metodo para obtener sedes por id
        public Sedes ObtenerSedePorId(int id)
        {
            var querySedesId = from s in ctx.Sedes where s.IdSede == id select s;

            Sedes sede = new Sedes();

            foreach (Sedes sedes in querySedesId)
            {
                sede.IdSede = sedes.IdSede;
                sede.Nombre = sedes.Nombre;
                sede.Direccion = sedes.Direccion;
                sede.PrecioGeneral = sedes.PrecioGeneral;
            }

            return sede;
        }


        
    }

}
