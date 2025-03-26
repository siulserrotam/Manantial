using API.Errors;
using Manantial.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Manantial.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorErrores : ControllerBase
    {
        private readonly ContextoTienda _context;  // Declaramos la variable _context para acceder a la base de datos

        // Constructor que recibe el contexto de la base de datos
        public ControladorErrores(ContextoTienda context)
        {
            _context = context;
        }

        // Simula un error 404 Not Found
        [HttpGet("noencontrado")]
        public ActionResult ObtenerRecursoNoEncontrado()
        {
            var producto = _context.Productos.Find(42); // Intentamos encontrar un producto con un ID que no existe

            if (producto == null)
            {
                // Si el producto no se encuentra, retornamos un error 404
                return NotFound(new RespuestaApi(404)); // Devolvemos un error con código 404
            }
            return Ok(producto); // Si el producto se encuentra, lo devolvemos
        }

        // Simula un error 500 Internal Server Error
        [HttpGet("errorservidor")]
        public ActionResult ObtenerErrorDeServidor()
        {
            var producto = _context.Productos.Find(42); // Intentamos buscar un producto que puede no existir

            if (producto == null)
            {
                // Si 'producto' es nulo, devolvemos un error 500 con un mensaje
                return StatusCode(500, "Producto no encontrado o algo salió mal."); // Error 500 con un mensaje
            }

            var productoString = producto.ToString(); // Esto solo se ejecuta si 'producto' no es nulo

            return Ok(); // Si todo va bien, respondemos con un código 200 OK
        }

        // Simula un error 400 Bad Request
        [HttpGet("solicitudincorrecta")]
        public ActionResult ObtenerSolicitudIncorrecta()
        {
            return BadRequest(new RespuestaApi(400)); // Devolvemos un error 400 Bad Request
        }

        // Simula un error 400 Bad Request con un parámetro
        [HttpGet("solicitudincorrecta/{id}")]
        public ActionResult ObtenerSolicitudIncorrectaConId(int id) // Recibe un ID como parámetro
        {
            if (id <= 0)
            {
                // Si el ID es menor o igual a cero, devolvemos un error 400 Bad Request
                return BadRequest(new RespuestaApi(400, "El ID debe ser mayor que cero."));
            }
            return Ok(); // Si el ID es válido, devolvemos OK
        }
    }
}
