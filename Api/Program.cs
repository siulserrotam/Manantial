using Microsoft.EntityFrameworkCore;
using Infraestructure.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion"))
);

builder.Services.AddControllers(); // Para manejar controladores si los necesitas en el futuro
builder.Services.AddEndpointsApiExplorer(); // Si quieres usar OpenAPI

// Registra Swagger para generar la documentación de la API
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Manantial.api", Version = "v1" });
    }
);

var app = builder.Build();

// Configurar la tubería de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilitar Swagger solo en desarrollo
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manantial API v1");
        c.RoutePrefix = string.Empty; // Para mostrar la UI de Swagger en la raíz de la web (opcional)
    }); 
}

app.UseHttpsRedirection(); // Redirección de HTTP a HTTPS

app.Run();
