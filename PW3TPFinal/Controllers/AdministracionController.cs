using PW3TPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PW3TPFinal.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Inicio()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Peliculas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Peliculas(Pelicula p)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Sedes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sedes(Sede s)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Carteleras()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Carteleras(Cartelera c)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Reportes()
        {
            return View();
        }
    }
}