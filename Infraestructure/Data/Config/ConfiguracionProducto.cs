using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infraestructure.Data.Config
{
    public class ConfiguracionProducto : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            // Configuración de propiedades
            builder.Property(p => p.Id).IsRequired(); // Asegura que el campo Id es obligatorio
            builder.Property(p => p.Nombre)
                .IsRequired() // Asegura que el nombre es obligatorio
                .HasMaxLength(100); // Longitud máxima de 100 caracteres
            builder.Property(p => p.Descripcion)
                .IsRequired() // Asegura que la descripción es obligatoria
                .HasMaxLength(180); // Longitud máxima de 180 caracteres
            builder.Property(p => p.Precio)
                .HasColumnType("decimal(18,2)"); // Tipo decimal con 18 dígitos y 2 decimales
            builder.Property(p => p.RutaImagen)
                .IsRequired(); // Asegura que la ruta de la imagen es obligatoria
            builder.Property(p => p.NombreImagen)
                .IsRequired(); // Asegura que el nombre de la imagen es obligatorio
            builder.Property(p => p.Stock)
                .IsRequired(); // Asegura que el stock es obligatorio

            // Configuración de relaciones
            builder.HasOne(p => p.Marca)
                .WithMany() // Una marca puede tener muchos productos
                .HasForeignKey(p => p.Fk_IdMarca); // Relación de clave foránea con la marca

            builder.HasOne(p => p.Categoria)
                .WithMany() // Una categoría puede tener muchos productos
                .HasForeignKey(p => p.Fk_IdCategoria); // Relación de clave foránea con la categoría
        }
    }
}
