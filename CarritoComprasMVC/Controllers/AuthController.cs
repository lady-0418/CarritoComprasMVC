using CarritoComprasMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoComprasMVC.Controllers
{
    public class AuthController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string usuario, string Contraseña)
        {
            var user = db.Usuarios.FirstOrDefault(u => u.Login == usuario && u.Contraseña == Contraseña);

            if(user != null)
            {
                Session["Usuario"] = user.Id;
                Session["Nombre"] = user.NombreCompleto;
                Session["Rol"] = user.Rol;

                if (user.Rol == 1)
                    return RedirectToAction("Panel", "Administrador");
                else
                    return RedirectToAction("Catalogo", "Comprador");
              
            }
            ViewBag.Mensaje = "Usuario o contraseña incorrectos";
            return View();

        }

        public ActionResult Registrar()
        {
            List<SelectListItem> lista = new List<SelectListItem>()
            {
                
            };
            SelectListItem li1 = new SelectListItem()
            {
                Text = "Administrador", Value = "1"
            };
            lista.Add(li1);
            SelectListItem li2 = new SelectListItem()
            {
                Text = "Cliente",
                Value = "2"
            };
            lista.Add(li2);
            ViewBag.lista = lista;
            return View();
        }
            

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            if(ModelState.IsValid)
            {              
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(usuario);
        }








    }
}