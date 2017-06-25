using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PW3TPFinal.DAL.Repositorios
{
    public class RepositorioBase
    {
        protected CresmontContext Contexto { get; set; }
        public RepositorioBase(CresmontContext ctx)
        {
            this.Contexto = ctx;
        }
    }

    
}