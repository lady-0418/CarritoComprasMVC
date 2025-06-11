using CarritoComprasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarritoComprasMVC.Controllers
{
    public class ComprarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Comprar(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto == null)

                return HttpNotFound();
            return View(producto);
        }
        [HttpPost]
        public ActionResult Comprar(int id, int cantidad)
        {
            var producto = db.Productos.Find(id);
            int usuarioId = Convert.ToInt32(Session["Usuario"]);

            if (producto == null || cantidad <= 0)
            {
                ViewBag.Mensaje = "Cantidad invalida.";
                return View(producto);
            }

            if (cantidad > producto.CantidadDisponible)
            {
                ViewBag.Mensaje = $"Solo hay{producto.CantidadDisponible} unidades disponibles.";
                return View(producto);
            }
            var transaccion = new Transacciones
            {
                UsuarioId = usuarioId,
                ProductoId = id,
                CantidadComprada = cantidad,
                FechaCompra = DateTime.Now
            };

            db.Transacciones.Add(transaccion);
            producto.CantidadDisponible -= cantidad;
            db.SaveChanges();

            return RedirectToAction("Catalogo", "Comprador");
        }
    }
}