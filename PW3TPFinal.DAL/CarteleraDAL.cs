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



    }
}

