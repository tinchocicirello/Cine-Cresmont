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
            return View();
        }

        // Controllers para las peliculas //
        [HttpGet]
        public ActionResult Peliculas()
        {
            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            return View();
        }

        [HttpGet]
        public ActionResult NuevaPelicula()
        {
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
            ViewBag.Sedes = sservice.ObtenerSedes();
            return View();
        }
        [HttpPost]
        public ActionResult Sedes(Sedes sede)
        {
            if (ModelState.IsValid)
            {
                sservice.GuardarSede(sede);
                return View();
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditarSede(int idSede)
        {
            ViewBag.Sede = sservice.ObtenerSedePorId(idSede);
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
            ViewBag.Sedes = sservice.ObtenerSedes(); 
            ViewBag.Peliculas = pservice.ObtenerPeliculas(); 
            ViewBag.Versiones = pservice.ObtenerVersiones(); 
            List<Carteleras> Carteleras = cservice.ObtenerCarteleras();

            List<Cartelera> listaCarteleras = new List<Cartelera>();

            foreach (Carteleras cartelera in Carteleras)
            {
                Cartelera c = new Cartelera();
                c.IdCartelera = cartelera.IdCartelera;
                c.Sede = sservice.ObtenerSedePorId(cartelera.IdSede).Nombre;
                c.Sala = cartelera.NumeroSala;
                c.Pelicula = pservice.ObtenerPeliculaPorId(cartelera.IdPelicula).Nombre;
                c.Version = rservice.ObtenerVersionPorId(cartelera.IdVersion).Nombre;
                c.FechaInicio = cartelera.FechaInicio;
                c.FechaFin = cartelera.FechaFin;
                listaCarteleras.Add(c);
            }

            return View(listaCarteleras);
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
            return View();
        }
        // fin Controllers para los reportes  //
    }
}