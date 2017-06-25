using PW3TPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PW3TPFinal.logica;
using PW3TPFinal.DAL;

namespace PW3TPFinal.Controllers
{
    public class AdministracionController : Controller
    {
        SedeService sservice = new SedeService();
        PeliculaService pservice = new PeliculaService();
        CarteleraService cservice = new CarteleraService();
        ReservaService rservice = new ReservaService();

        CresmontContext ctx = new CresmontContext();

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
        [HttpGet]
        public ActionResult Reportes()
        {
            return View();
        }
    }
}