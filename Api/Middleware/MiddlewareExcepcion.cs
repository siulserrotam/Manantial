using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Manantial.Api.Middleware
{
    public class MiddlewareExcepcion
    {
        private readonly RequestDelegate _siguiente;

        // Constructor que recibe el siguiente middleware en la tubería de ejecución
        public MiddlewareExcepcion(RequestDelegate siguiente)
        {
            _siguiente = siguiente;
        }

        // Método que intercepta cada solicitud HTTP
        public async Task InvocarAsync(HttpContext contexto)
        {
            try
            {
                // Ejecuta el siguiente middleware en la cadena
                await _siguiente(contexto);
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción no manejada y la procesa
                await ManejarExcepcionAsync(contexto, ex);
            }
        }

        // Método para manejar excepciones y generar una respuesta adecuada
        private Task ManejarExcepcionAsync(HttpContext contexto, Exception excepcion)
        {
            // Especifica que la respuesta será en formato JSON
            contexto.Response.ContentType = "application/json";

            // Define el código de estado HTTP como 500 (Error interno del servidor)
            contexto.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Crea un objeto con los detalles del error para enviarlo como respuesta
            var respuesta = new
            {
                CodigoEstado = contexto.Response.StatusCode, // Código de error HTTP
                Mensaje = "Ocurrió un error inesperado. Por favor, inténtelo de nuevo más tarde.", // Mensaje genérico para el usuario
                Detalles = excepcion.Message // Mensaje específico de la excepción (útil para depuración)
            };

            // Escribe la respuesta en el cuerpo de la respuesta HTTP en formato JSON
            return contexto.Response.WriteAsJsonAsync(respuesta);
        }
    }
}
