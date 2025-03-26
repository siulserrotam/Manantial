using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Manantial.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControladorDeErrores : ControllerBase
    {
         // Método para manejar errores globales de la aplicación
        [Route("/error")]
        public IActionResult ManejarError()
        {
            var detallesError = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var excepcion = detallesError?.Error;

            // Crear una respuesta personalizada con los detalles del error
            var respuestaError = new
            {
                mensaje = "Ocurrió un error inesperado en el servidor.",
                detalle = excepcion?.Message,
                pila = excepcion?.StackTrace,
                codigo = 500
            };

            // Devuelve un error con el código de estado 500 (Error Interno del Servidor)
            return StatusCode(500, respuestaError);
        }
    }
}