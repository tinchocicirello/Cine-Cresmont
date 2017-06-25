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
        /*
        PeliculaService pservice = new PeliculaService();
        ReservaService rservice = new ReservaService();
        CarteleraService cservice = new CarteleraService();
        SedeService sservice = new SedeService();*/

        //
        // GET: /Home/

        public ActionResult Inicio()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                using (CresmontContext ctx = new CresmontContext())
                {
                    var loginUser = ctx.Usuarios.Where(a => a.NombreUsuario.Equals(usuario.NombreUsuario) && a.Password.Equals(usuario.Password)).FirstOrDefault();

                    if (loginUser != null)
                    {
                        Session["IdUser"] = loginUser.IdUsuario.ToString();
                        Session["username"] = loginUser.NombreUsuario;
                        return RedirectToAction("Home");
                    }
                }

            }

            return View();
        }

        public ActionResult Home()
        {
            if (Session["IdUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Inicio");
        }
    }

}