using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CarritoComprasMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string Login { get; set; }
        public string Identificacion { get; set; }        
        public string Contraseña { get; set; }
        public Int16 Rol { get; set; }


    }
}