using CarritoComprasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoComprasMVC.Controllers
{
    public class CompradorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //mostrar productos disponibles
        public ActionResult Catalogo()
        {
            var productos = db.Productos
                .Where(p => p.CantidadDisponible > 0)
                .ToList();
            return View(productos);
        }

       
    }
}