using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;


namespace CarritoComprasMVC.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("conexion") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }


    }
}