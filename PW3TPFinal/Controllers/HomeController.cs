using PW3TPFinal.Models;
using PW3TPFinal.logica;
using PW3TPFinal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PW3TPFinal.Controllers
{
    public class HomeController : Controller
    {


         /////////////////////
        //      HOME       //
       /////////////////////

        PeliculaService pservice = new PeliculaService();
        ReservaService rservice = new ReservaService();
        CarteleraService cservice = new CarteleraService();
        SedeService sservice = new SedeService();

        // resuelve inicio //
        [HttpGet]
        public ActionResult Inicio()
        {
            ViewBag.Peliculas = pservice.ObtenerPeliculas();
            return View();
        }


        // resuelve login //
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Inicio", "Administracion");
            }

            return View();

        }

        [HttpPost]
        public ActionResult Login(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                //using (CresmontContext ctx = new CresmontContext())
                //{
                    //var user = ctx.Usuarios.Where(a => a.NombreUsuario.Equals(usuario.NombreUsuario) && a.Password.Equals(usuario.Password)).FirstOrDefault();

                    
                    if (usuario.NombreUsuario == "admin" && usuario.Password == "123")
                    {
                        Session["user"] = usuario.NombreUsuario;
                        if(Session["redirect"] != null)
                        {
                            return RedirectToAction((String)Session["redirect"], "Administracion");
                        }
                        return RedirectToAction("Home");
                    }
                //}

            }

            return View();
        }

        // resuelve home //
        [HttpGet]
        public ActionResult Home()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Inicio", "Administracion");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        // resuelve logout //
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Inicio");
        }
    }

}