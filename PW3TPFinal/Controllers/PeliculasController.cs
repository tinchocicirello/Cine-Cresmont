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
    public class PeliculasController : Controller
    {

        ReservaService rservice = new ReservaService();
        SedeService sservice = new SedeService();
        PeliculaService pservice = new PeliculaService();
        CarteleraService cservice = new CarteleraService();

        [HttpGet]
        public ActionResult Reserva(int id)
        {
            Session["idPeli"] = id;
            ViewBag.Versiones = rservice.ObtenerVersiones(id);
            ViewBag.Pelicula = pservice.ObtenerPeliculaPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult Reserva(ReservaInicial r)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("ConfirmarReserva", r);
            }

            return View(r);
        }

        public ActionResult ConfirmarReserva(ReservaInicial r)
        {
            ViewBag.Reserva = rservice.ObtenerCarteleraPorPeliculaVersionSede(r.IdPelicula, r.IdVersion, r.IdSede);
            ViewBag.FechaReserva = r.Fecha;
            ViewBag.TiposDocumento = rservice.ObtenerTiposDocumento();
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmarReserva(Reserva r, Reservas reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.FechaCarga = DateTime.Now;
                rservice.CrearReserva(reserva);
                TempData["ReservaConfirmada"] = "Tu reserva se realizó con éxito!";
                return RedirectToAction("Inicio", "Home");
            }

            ViewBag.Reserva = rservice.ObtenerCarteleraPorPeliculaVersionSede(reserva.IdPelicula, reserva.IdVersion, reserva.IdSede);
            ViewBag.FechaReserva = reserva.FechaHoraInicio;
            ViewBag.TiposDocumento = rservice.ObtenerTiposDocumento();
            return View(r);
        }

        /*[HttpPost]
        public ActionResult ConfirmarReserva(ReservaInicial ri, Reserva r)
        {
            if (ModelState.IsValid)
            {
                Reservas reserva = new Reservas();
                reserva.FechaHoraInicio = DateTime.Now;
                reserva.FechaCarga = DateTime.Now;
                rservice.CrearReserva(reserva);

                return RedirectToAction("Inicio", "Home");
            }

            ViewBag.Sedes = sservice.ObtenerSedes();
            ViewBag.Versiones = rservice.ObtenerVersiones((int)Session["idPeli"]);
            ViewBag.Fechas = rservice.ObtenerReservaPorFecha();
            ViewBag.Horas = rservice.ObtenerReservaPorHorario();
            return View(r);
        }*/

        [HttpPost]
        public JsonResult SedeReserva(string id)
        {
            int idVersion = Convert.ToInt32(id);
            int idPelicula = (int)Session["idPeli"];
            List<Sedes> listaSedes = cservice.ObtenerSedesPorPelicula(idPelicula, idVersion);

            List<SelectListItem> sedes = new List<SelectListItem>();
            foreach (Sedes s in listaSedes)
            {
                sedes.Add(new SelectListItem { Text = @s.Nombre, Value = @s.IdSede.ToString() });
            }
            return Json(new SelectList(sedes, "Value", "Text", "Seleccione Sala"));
        }

        //Metodo para filtrar fechas
        public JsonResult ObtenerFechaHoraReserva(string idSede, string idVersion)
        {
            
            int pelicula = (int)Session["idPeli"];
            int version = Convert.ToInt32(idVersion);
            int sede = Convert.ToInt32(idSede);

            Carteleras cartelera = rservice.ObtenerCarteleraPorPeliculaVersionSede(pelicula, version, sede);

            DateTime finicio = cartelera.FechaInicio;
            DateTime ffin = cartelera.FechaFin;
            List<DateTime> listaFechas = new List<DateTime>();

            while(finicio <= ffin)
            {
                if(finicio.DayOfWeek == DayOfWeek.Monday && cartelera.Lunes == true)
                {
                    listaFechas.Add(finicio);
                }
                else if (finicio.DayOfWeek == DayOfWeek.Tuesday && cartelera.Martes == true)
                {
                    listaFechas.Add(finicio);
                }
                else if (finicio.DayOfWeek == DayOfWeek.Wednesday && cartelera.Miercoles == true)
                {
                    listaFechas.Add(finicio);
                }
                else if (finicio.DayOfWeek == DayOfWeek.Thursday && cartelera.Jueves == true)
                {
                    listaFechas.Add(finicio);
                }
                else if (finicio.DayOfWeek == DayOfWeek.Friday && cartelera.Viernes == true)
                {
                    listaFechas.Add(finicio);
                }
                else if (finicio.DayOfWeek == DayOfWeek.Saturday && cartelera.Sabado == true)
                {
                    listaFechas.Add(finicio);
                }
                else if (finicio.DayOfWeek == DayOfWeek.Sunday && cartelera.Domingo == true)
                {
                    listaFechas.Add(finicio);
                }

                finicio = finicio.AddDays(1);
            }
            
            List<SelectListItem> fechas = new List<SelectListItem>();

            foreach (DateTime dia in listaFechas)
            {
                string fecha = dia.ToString("dd/MM/yyyy") + " " + cartelera.HoraInicio + ":00:00";
                fechas.Add(new SelectListItem { Value = fecha, Text = fecha });
            }
                

            return Json(new SelectList(fechas, "Value", "Text"));
        }
    }
}