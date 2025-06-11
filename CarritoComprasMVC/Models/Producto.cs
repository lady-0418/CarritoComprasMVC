using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoComprasMVC.Models
{
    public class Productos
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }

        public int CantidadDisponible { get; set; }

        public string Descripcion { get; set; }

      


    }
}