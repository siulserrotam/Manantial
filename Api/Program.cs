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

var builder = WebApplication.CreateBuilder(args);

// Configuración del DbContext para conectar a SQL Server
builder.Services.AddDbContext<ContextoTienda>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion")));

// Agregar servicios adicionales
builder.Services.AddScoped<SemillaContextoTienda>();
builder.Services.AddScoped<ProductoUrlResolver>();

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(PerfilesDeMapeo));

// Configuración de controladores con compatibilidad para respuestas de error personalizadas
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
builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manantial API", Version = "v1" });
});

// Habilitar exploración de endpoints
builder.Services.AddEndpointsApiExplorer();

// Construcción de la aplicación
var app = builder.Build();

// Middleware para manejar errores globales
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manantial API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Aplicar migraciones de la base de datos
await AplicarMigracionesAsync(app);

app.Run();

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
