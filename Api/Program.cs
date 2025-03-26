
using Manantial.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Agregar servicios al contenedor.

        // Configuración de la cadena de conexión de la base de datos
        builder.Services.AddDbContext<ContextoTienda>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion"))
        );

        // Habilitar la exploración de endpoints para OpenAPI
        builder.Services.AddEndpointsApiExplorer();

        // Configuración de Swagger para la documentación de la API
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manantial.api", Version = "v1" });
        });

        // Habilitar CORS (si es necesario para tus necesidades)
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()  // Permite cualquier origen
                       .AllowAnyMethod()  // Permite cualquier método HTTP (GET, POST, PUT, DELETE)
                       .AllowAnyHeader(); // Permite cualquier encabezado
            });
        });

        var app = builder.Build();

        // Configurar la tubería de solicitud HTTP.

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger(); // Habilitar Swagger solo en entorno de desarrollo
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manantial API v1");
                c.RoutePrefix = string.Empty; // Muestra la UI de Swagger en la raíz de la web (opcional)
            });
        }

        // Configurar manejo global de errores
        app.UseExceptionHandler("/error"); // Ruta global para manejar errores (esto debe estar antes de cualquier middleware que maneje solicitudes)

        app.UseHttpsRedirection(); // Redirección de HTTP a HTTPS

        // Configurar CORS
        app.UseCors("AllowAll");

        // Iniciar la aplicación
        app.Run();
    }
}