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

        [HttpGet]
        public ActionResult Reserva()
        {
            ViewBag.Versiones = rservice.ObtenerVersiones();
            ViewBag.Sedes = sservice.ObtenerSedes();
            ViewBag.Dias = rservice.ObtenerReservaPorFecha();
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmarReserva()
        {
            ViewBag.Sedes = sservice.ObtenerSedes();
            ViewBag.Versiones = rservice.ObtenerVersiones();
            ViewBag.Fechas = rservice.ObtenerReservaPorFecha();
            ViewBag.Horas = rservice.ObtenerReservaPorHorario();
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmarReserva(Reservas reserva)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return View();
        }
    }
}