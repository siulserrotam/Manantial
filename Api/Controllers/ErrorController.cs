using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // Ruta para manejar errores con un código de estado HTTP personalizado
    [Route("errores/{codigo}")]
    [ApiExplorerSettings(IgnoreApi = true)]  // Ignora la API en la documentación de Swagger
    public class ErrorController : ControladorBaseApi
    {
        // Acción que devuelve una respuesta de error con un código de estado HTTP proporcionado
        public IActionResult Error(int codigo)
        {
            // Retorna un objeto con el código de error proporcionado y un mensaje de respuesta
            return new ObjectResult(new RespuestaApi(codigo));
        }
    }
}