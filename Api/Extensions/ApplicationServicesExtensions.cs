using API.Errors;
using Manantial.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Manantial.Infraestructure.Repositories;
using Manantial.Infraestructure.Rrepositories;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registra el repositorio de productos para inyección de dependencias
            services.AddScoped<IRepositorioProducto, RepositorioProducto>(); // Registra la implementación del repositorio de productos

            // Registra el repositorio genérico para ser usado con cualquier tipo de entidad
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));  // Registra el repositorio genérico con inyección de dependencias
                        
            // Configuración personalizada para manejar errores de modelo en las respuestas de la API
            services.Configure<ApiBehaviorOptions>(Option => 
            {
                // Personalizamos la respuesta cuando el estado del modelo es inválido
                Option.InvalidModelStateResponseFactory = ActionContext => 
                {
                    // Extrae los mensajes de error del estado del modelo
                    var errors = ActionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    // Crea una respuesta de error con los mensajes de error
                    var errorResponse = new RespuestaErrorValidacionApi
                    {
                        Errores = errors
                    };
                    return new BadRequestObjectResult(errorResponse);  // Devuelve un error 400 BadRequest con los errores
                };
            });

            return services;
        }
    }
}