using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdaApi.Models
{
    [Table("Productos")]
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int CantidadDisponible { get; set; }
    }
}
