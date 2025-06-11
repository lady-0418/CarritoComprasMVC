using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarritoComprasMVC.Models
{
    public class Transacciones
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadComprada { get; set; }
        public DateTime FechaCompra { get; set; } =DateTime.Now;

        public virtual Usuario Usuario { get; set; }
        public virtual Productos Producto { get; set; }
    }
}