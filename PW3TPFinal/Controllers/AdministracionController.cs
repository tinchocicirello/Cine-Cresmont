using PW3TPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PW3TPFinal.logica;
using PW3TPFinal.DAL;
using System.IO;
using PW3TPFinal.Utilities;

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
        public ActionResult NuevaPelicula(Peliculas p, HttpPostedFileBase img, Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {

                /*string carpetaImagenes = System.Configuration.ConfigurationManager.AppSettings["Peliculas"];
                string pathDestino = System.Web.Hosting.HostingEnvironment.MapPath("~") + carpetaImagenes;
                string nombreArchivo = string.Concat(pathDestino, Path.GetFileName(img.FileName));
                img.SaveAs(nombreArchivo);
                var archivoOriginal = img.FileName;
                var archivoNuevo = "cresmont-imagenes-"+archivoOriginal;
                var path = Path.Combine(Server.MapPath("~/Content/images/Peliculas"), archivoNuevo);
                img.SaveAs(path);
                p.Imagen = path;*/


                //Agregar imagen
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    //TODO: Agregar validacion para confirmar que el archivo es una imagen
                    string nombreSignificativo = pelicula.Nombre;
                    //Guardar Imagen
                    string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                    p.Imagen = pathRelativoImagen;
                }
                else
                {
                    p.Imagen = "/Content/images/Peliculas/default.png";
                }

                p.FechaCarga = DateTime.Now;

                pservice.AgregarPelicula(p);
                return RedirectToAction("Peliculas");
            }

            ViewBag.Calificaciones = pservice.ObtenerCalificaciones();
            ViewBag.Generos = pservice.ObtenerGeneros();
            return View();
        }

        [HttpGet]
        public ActionResult EditarPelicula(int id)
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "EditarPelicula";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Calificaciones = pservice.ObtenerCalificaciones();
            ViewBag.Generos = pservice.ObtenerGeneros();
            ViewBag.Pelicula = pservice.ObtenerPeliculaPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult EditarPelicula(Peliculas pelicula, Pelicula p)
        {
            if (ModelState.IsValid)
            {

                //Agregar imagen
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    //TODO: Agregar validacion para confirmar que el archivo es una imagen
                    string nombreSignificativo = p.Nombre;
                    //Guardar Imagen
                    string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                    pelicula.Imagen = pathRelativoImagen;
                }
                else
                {
                    pelicula.Imagen = "/Content/images/Peliculas/default.png";
                }

                pservice.ActualizarPelicula(pelicula);
                return RedirectToAction("Peliculas");
            }
            ViewBag.Calificaciones = pservice.ObtenerCalificaciones();
            ViewBag.Generos = pservice.ObtenerGeneros();
            ViewBag.Pelicula = pservice.ObtenerPeliculaPorId(pelicula.IdPelicula);
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
        public ActionResult Sedes(Sedes sede, Sede s)
        {
            if (ModelState.IsValid) 
            {
                sservice.GuardarSede(sede);
                return RedirectToAction("Sedes");
            }

            ViewBag.Sedes = sservice.ObtenerSedes();
            return View(s);
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

            ViewBag.Carteleras = cservice.ObtenerCarteleras();
            return View();
        }

        [HttpGet]
        public ActionResult NuevaCartelera()
        {

            if (Session["user"] == null)
            {
                Session["redirect"] = "NuevaCartelera";
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            ViewBag.Versiones = pservice.ObtenerVersiones();
            ViewBag.Sedes = cservice.ObtenerSedesDisponiblesCarteleras();
            return View();
        }

        [HttpPost]
        public ActionResult NuevaCartelera(Carteleras c, Cartelera cartelera)
        {
            if (ModelState.IsValid)
            {
                c.FechaCarga = DateTime.Now;
                cservice.AgregarCartelera(c);
                return RedirectToAction("Carteleras");
            }

            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            ViewBag.Versiones = pservice.ObtenerVersiones();
            ViewBag.Sedes = cservice.ObtenerSedesDisponiblesCarteleras();
            return View(cartelera);
        }

        [HttpGet]
        public ActionResult EditarCartelera(int id)
        {
            if (Session["user"] == null)
            {
                Session["redirect"] = "EditarCartelera";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Cartelera = cservice.ObtenerCartelerasPorId(id);
            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            ViewBag.Versiones = pservice.ObtenerVersiones();
            ViewBag.Sedes = cservice.ObtenerSedesDisponiblesCarteleras();
            return View();
        }

        [HttpPost]
        public ActionResult EditarCartelera(Cartelera c, Carteleras cartelera)
        {
            if(ModelState.IsValid)
            {
                cservice.EditarCartelera(cartelera);
                return RedirectToAction("Carteleras");
            }

            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            ViewBag.Versiones = pservice.ObtenerVersiones();
            ViewBag.Sedes = cservice.ObtenerSedesDisponiblesCarteleras();
            return View(c);
        }


        [HttpGet]
        public ActionResult EliminarCartelera(int id)
        {

            if (Session["user"] == null)
            {
                Session["redirect"] = "EliminarCartelera";
                return RedirectToAction("Login", "Home");
            }
            cservice.BorrarCartelera(id);
            return RedirectToAction("Carteleras");
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
        public ActionResult ReporteReserva(Reporte r)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Reserva = rservice.ObtenerReservaPorFechayPelicula(r.FechaInicio, r.FechaFin, r.IdPelicula);
            }
            
            return View(r);
        }
        // fin Controllers para los reportes  //
    }
}