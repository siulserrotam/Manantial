using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using API.Errors;
using Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 🛠️ 1. Configuración del DbContext para conectar a SQL Server
builder.Services.AddDbContext<ContextoTienda>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

// 🛠️ 2. Inyección de dependencias para repositorios
builder.Services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<IRepositorioProducto, RepositorioProducto>();

// 🛠️ 3. Inyección de servicios adicionales
builder.Services.AddScoped<SemillaContextoTienda>();
builder.Services.AddScoped<ProductoUrlResolver>();

// 🛠️ 4. Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(PerfilesDeMapeo));

// 🛠️ 5. Configuración de validaciones y respuestas de error
builder.Services.Configure<ApiBehaviorOptions>(opciones =>
{
    opciones.InvalidModelStateResponseFactory = actionContext =>
    {
        var errores = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(e => e.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToArray();

        var respuesta = new RespuestaApi(400, "Error en la solicitud", errores);
        return new BadRequestObjectResult(respuesta);
    };
});

// 🛠️ 6. Configuración de controladores
builder.Services.AddControllers();

// 🛠️ 7. Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manantial API", Version = "v1" });
});

// 🛠️ 8. Construcción de la aplicación
var app = builder.Build();

// 🛠️ 9. Middleware global para manejo de excepciones
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var contextoError = context.Features.Get<IExceptionHandlerFeature>();
        if (contextoError != null)
        {
            var respuesta = new RespuestaApi(500, "Error interno del servidor");
            var json = JsonSerializer.Serialize(respuesta);
            await context.Response.WriteAsync(json);
        }
    });
});

// 🛠️ 10. Configuración de Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manantial API v1");
        c.RoutePrefix = string.Empty;
    });
}

// 🛠️ 11. Configuración de middleware y enrutamiento
app.UseStatusCodePages(); // Devuelve más detalles de errores HTTP
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization(); // ❌ Si no usas autenticación, puedes quitar esto
app.MapControllers();

// 🛠️ 12. Aplicar migraciones de la base de datos
await AplicarMigracionesAsync(app);

app.Run();

// 🛠️ 13. Método para aplicar migraciones automáticamente
static async Task AplicarMigracionesAsync(WebApplication app)
{
    using (var alcance = app.Services.CreateScope())
    {
        var servicios = alcance.ServiceProvider;
        var loggerFactory = servicios.GetRequiredService<ILoggerFactory>();

        try
        {
            var contexto = servicios.GetRequiredService<ContextoTienda>();
            await contexto.Database.MigrateAsync();
            await SemillaContextoTienda.SembrarDatosAsync(contexto, loggerFactory);
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "Ocurrió un error durante la migración");
        }
    }
}
