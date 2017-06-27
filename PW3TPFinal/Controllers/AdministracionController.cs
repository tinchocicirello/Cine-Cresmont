using PW3TPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PW3TPFinal.logica;
using PW3TPFinal.DAL;
using System.IO;

namespace PW3TPFinal.Controllers
{
    public class AdministracionController : Controller
    {
        SedeService sservice = new SedeService();
        PeliculaService pservice = new PeliculaService();
        CarteleraService cservice = new CarteleraService();
        ReservaService rservice = new ReservaService();

        CresmontContext ctx = new CresmontContext();


          ////////////////////
         // Administracion //
        ////////////////////

        // Inicio controller
        public ActionResult Inicio()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        // Controllers para las peliculas //
        [HttpGet]
        public ActionResult Peliculas()
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "Peliculas";
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            return View();
        }

        [HttpGet]
        public ActionResult NuevaPelicula()
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "NuevaPelicula";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Calificaciones = pservice.ObtenerCalificaciones();
            ViewBag.Generos = pservice.ObtenerGeneros();
            return View();
        }

        [HttpPost]
        public ActionResult NuevaPelicula(Peliculas p, HttpPostedFileBase img)
        {

            var nombreArchivo = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + Path.GetFileName(img.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/images/Peliculas/"), nombreArchivo);
            img.SaveAs(path);
            p.Imagen = path;
            p.FechaCarga = DateTime.Now;

            pservice.AgregarPelicula(p);
            return RedirectToAction("Peliculas");
        }

        [HttpGet]
        public ActionResult EditarPelicula()
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "EditarPelicula";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Calificaciones = pservice.ObtenerCalificaciones();
            ViewBag.Generos = pservice.ObtenerGeneros();
            return View();
        }

        [HttpPost]
        public ActionResult EditarPelicula(Peliculas p)
        {
            return View();
        }
        // fin Controllers para las peliculas //

        // Controllers para las sedes //
        [HttpGet]
        public ActionResult Sedes()
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "Sedes";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Sedes = sservice.ObtenerSedes();
            return View();
        }

        [HttpPost]
        public ActionResult Sedes(Sedes sede)
        {
            if (ModelState.IsValid) 
            {
                sservice.GuardarSede(sede);
                return RedirectToAction("Sedes");
            }

            return View(sede);
        }

        [HttpGet]
        public ActionResult EditarSede(int id)
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "EditarSede";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Sede = sservice.ObtenerSedePorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult EditarSede(Sedes sede)
        {
            sservice.ActualizarSede(sede);
            return RedirectToAction("Sedes");
        }
        // fin Controllers para las sedes //

        // Controllers para las carteleras //
        [HttpGet]
        public ActionResult Carteleras()
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "Carteleras";
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Carteleras(Cartelera c)
        {
            return View();
        }
        // fin Controllers para las carteleras //

        // Controllers para los reportes //
        [HttpGet]
        public ActionResult Reportes()
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "Reportes";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            return View();
        }

        [HttpPost]
        public ActionResult ReporteReserva()
        {
            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            return View();
        }
        // fin Controllers para los reportes  //
    }
}