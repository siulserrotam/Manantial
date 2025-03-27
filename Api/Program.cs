using Manantial.Infraestructure.Data;  // Espacio de nombres para el contexto de la base de datos
using Microsoft.EntityFrameworkCore;  // Para trabajar con Entity Framework Core
using Microsoft.OpenApi.Models;  // Para la documentación Swagger
using Microsoft.Extensions.Logging;  // Para los servicios de logging
using Microsoft.AspNetCore.Mvc;  // Para los controladores
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);  // Crea un constructor para la aplicación

// Configuración del DbContext para conectar a SQL Server usando la cadena de conexión del archivo de configuración
builder.Services.AddDbContext<ContextoTienda>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

// Agregar servicios adicionales necesarios para la aplicación (como el repositorio y otros servicios)
builder.Services.AddScoped<SemillaContextoTienda>();  // Registrar el servicio de siembra de datos

// Configuración para usar Swagger en la documentación de la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manantial API", Version = "v1" });
});

// Registrar controladores
builder.Services.AddControllers();  // Registra los controladores de la API

// Habilitar la exploración de endpoints para OpenAPI
builder.Services.AddEndpointsApiExplorer();

// Habilitar los servicios de logging
builder.Services.AddLogging();

// Construcción de la aplicación
var app = builder.Build();

// Configuración de la tubería de middleware

if (app.Environment.IsDevelopment())  // Solo en desarrollo habilitar Swagger
{
    app.UseSwagger();  // Habilitar Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manantial API v1");
        c.RoutePrefix = string.Empty;  // Muestra Swagger en la raíz
    });
}

app.UseHttpsRedirection();  // Redirige las solicitudes HTTP a HTTPS

app.UseRouting();  // Configura el enrutamiento de las solicitudes a los controladores

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Mapea los controladores de la API
});

// Aplica las migraciones de la base de datos al iniciar la aplicación
await AplicarMigracionesAsync(app);  // Aplica las migraciones pendientes y siembra los datos

// Inicia la aplicación
app.Run();  // Ejecuta la aplicación web

// Método para aplicar migraciones al inicio de la aplicación
static async Task AplicarMigracionesAsync(WebApplication app)
{
    using (var alcance = app.Services.CreateScope())  // Crea un alcance para obtener los servicios
    {
        var servicios = alcance.ServiceProvider;  // Obtiene el proveedor de servicios
        var loggerFactory = servicios.GetRequiredService<ILoggerFactory>();  // Obtiene la fábrica de logs

        try
        {
            var contexto = servicios.GetRequiredService<ContextoTienda>();  // Obtiene el contexto de la base de datos
            await contexto.Database.MigrateAsync();  // Aplica las migraciones pendientes

            // Siembra los datos iniciales (solo si es necesario)
            await SemillaContextoTienda.SembrarDatosAsync(contexto, loggerFactory);
        }
        catch (Exception ex)
        {
            // Si ocurre un error, se registra el error en el log
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "Ocurrió un error durante la migración");
        }
    }
}
