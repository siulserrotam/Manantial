using Microsoft.EntityFrameworkCore;
using Infraestructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaConexion"))
);

builder.Services.AddControllers(); // Para manejar controladores si los necesitas en el futuro
builder.Services.AddEndpointsApiExplorer(); // Si quieres usar OpenAPI
//builder.Services.AddSwaggerGen(); // Para la documentación de la API si lo deseas

var app = builder.Build();
/*
// Configurar la tubería de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilitar Swagger solo en desarrollo
    app.UseSwaggerUI(); // Interfaz de usuario de Swagger
}
*/
app.UseHttpsRedirection(); // Redirección de HTTP a HTTPS

// Aquí eliminarás cualquier controlador de ejemplo, como `/weatherforecast`
// Ahora puedes añadir tus propios controladores de API cuando los crees

app.MapControllers(); // Asegúrate de mapear los controladores de la API

app.Run();
