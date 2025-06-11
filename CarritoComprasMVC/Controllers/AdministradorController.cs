using CarritoComprasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CarritoComprasMVC.Controllers
{
    public class AdministradorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Transacciones hechas por usuarios
        public ActionResult Panel()
        {
            List<Transacciones> transacciones = db.Transacciones
            .Include(t => t.Usuario)
            .Include(t => t.Producto)
            .OrderByDescending(t => t.FechaCompra)
            .ToList();

            return View(transacciones);
        }
    }
}