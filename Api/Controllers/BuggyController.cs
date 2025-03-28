using API.Errors;
using Manantial.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Controlador para manejo de errores
    public class BuggyController : ControladorBaseApi
    {
        private readonly ContextoTienda _contexto; // Se debe declarar la variable _context

        public BuggyController(ContextoTienda contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("noencontrado")]
        public ActionResult ObtenerRecursoNoEncontrado()
        {
            var producto = _contexto.Productos.Find(42); // Buscamos un producto que no existe

            if (producto == null)
            {
                return NotFound(new RespuestaApi(404)); // Devolver un error 404 si el objeto no fue encontrado
            }
            return Ok(producto); // Devolver el objeto encontrado si no es nulo
        }

        [HttpGet("errorservidor")]
        public ActionResult ObtenerErrorServidor()
        {
            var producto = _contexto.Productos.Find(42); // Intentamos encontrar un producto que puede no existir

            if (producto == null)
            {
                // Si 'producto' es nulo, devolvemos un error 500 con un mensaje personalizado
                return StatusCode(500, "Producto no encontrado o algo salió mal.");
            }

            var productoString = producto.ToString(); // Esto solo se ejecuta si 'producto' no es nulo

            return Ok(); // Devolvemos una respuesta exitosa
        }

        [HttpGet("solicitudincorrecta")]
        public ActionResult ObtenerSolicitudIncorrecta()
        {
            return BadRequest(new RespuestaApi(400)); // Devolver un error 400
        }

        [HttpGet("solicitudincorrecta/{id}")]
        public ActionResult ObtenerSolicitudIncorrectaConId(int id)
        {
            return Ok(); // Devolver una respuesta correcta
        }
    }
}
