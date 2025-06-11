using AdaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> Get()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> Get(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound(); 
            }

            return Ok(producto); 
        }


        [HttpPost]
        public async Task<ActionResult<Productos>> Post(Productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Productos producto)
        {
            if (id != producto.Id)
            {
                return BadRequest("El ID de la URL no coincide con el del cuerpo.");
            }

            var productoExistente = await _context.Productos.FindAsync(id);
            if (productoExistente == null)
            {
                return NotFound("No se encontró el producto.");
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.CantidadDisponible = producto.CantidadDisponible;

            await _context.SaveChangesAsync();

            return Ok("Producto actualizado correctamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto); 
            await _context.SaveChangesAsync();   

            return Ok("Producto eliminado con éxito");
        }

    }
}

