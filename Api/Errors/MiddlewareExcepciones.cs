using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Errors
{
    public class MiddlewareExcepciones
    {
        private readonly RequestDelegate _siguiente;

        public MiddlewareExcepciones(RequestDelegate siguiente)
        {
            _siguiente = siguiente;
        }

        public async Task InvokeAsync(HttpContext contexto)
        {
            try
            {
                // Continúa con el siguiente middleware en la cadena
                await _siguiente(contexto);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra en la ejecución
                await ManejarExcepcionAsync(contexto, ex);
            }
        }

        private async Task ManejarExcepcionAsync(HttpContext contexto, Exception excepcion)
        {
            contexto.Response.ContentType = "application/json";
            contexto.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // Código 500 (Error interno del servidor)

            var respuesta = new
            {
                CodigoEstado = contexto.Response.StatusCode,
                Mensaje = "Ocurrió un error inesperado. Intente nuevamente más tarde.",
                Detalles = excepcion.Message // Opcional: puedes omitirlo en producción
            };

            var opcionesJson = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var respuestaJson = JsonSerializer.Serialize(respuesta, opcionesJson);

            await contexto.Response.WriteAsync(respuestaJson);
        }
    }
}
