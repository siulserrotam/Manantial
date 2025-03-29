using System.Reflection;
using Core.Entities;  // Hace referencia a las entidades del modelo de la base de datos.
using Microsoft.EntityFrameworkCore;  // Contiene las clases y métodos para trabajar con Entity Framework Core.

namespace Infraestructure.Data  // Espacio de nombres donde se maneja el contexto de la base de datos.
{
    public class ContextoTienda : DbContext
    {
        // Constructor que recibe un objeto DbContextOptions con la configuración de la base de datos.
        public ContextoTienda(DbContextOptions<ContextoTienda> options) : base(options)
        {
        }

        // Propiedades DbSet que representan las tablas en la base de datos.
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Barrio> Barrios { get; set; }

        // Método OnModelCreating utilizado para configurar las entidades y sus relaciones.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Llama al método base para mantener la configuración predeterminada.

            // Configurar claves primarias explícitas
            modelBuilder.Entity<Departamento>().HasKey(d => d.IdDepartamento);  // Definir la clave primaria de Departamento
            modelBuilder.Entity<Ciudad>().HasKey(c => c.IdCiudad);  // Definir la clave primaria de Ciudad
            modelBuilder.Entity<Barrio>().HasKey(b => b.IdBarrio);  // Definir la clave primaria de Barrio
            modelBuilder.Entity<Carrito>().HasKey(c => c.IdCarrito);  // Definir la clave primaria de Carrito
            modelBuilder.Entity<DetalleVenta>().HasKey(dv => dv.IdDetalleVenta);  // Definir la clave primaria de DetalleVenta

            // Configuración de las relaciones entre las entidades

            // Relación opcional entre Barrio y Departamento
            modelBuilder.Entity<Barrio>()
                .HasOne(b => b.Departamento)  // Barrio tiene una relación con Departamento
                .WithMany()  // Un Departamento puede tener muchos Barrios
                .HasForeignKey(b => b.Fk_IdDepartamento)  // Clave foránea
                .OnDelete(DeleteBehavior.Restrict);  // Evitar cascada para evitar ciclos

            // Relación opcional entre Barrio y Ciudad
            modelBuilder.Entity<Barrio>()
                .HasOne(b => b.Ciudad)  // Barrio tiene una relación con Ciudad
                .WithMany()  // Una Ciudad puede tener muchos Barrios
                .HasForeignKey(b => b.Fk_IdCiudad)  // Clave foránea
                .OnDelete(DeleteBehavior.Restrict);  // Evitar cascada para evitar ciclos

            // Relación de DetalleVenta con Venta
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Venta)  // DetalleVenta tiene una relación con Venta
                .WithMany()  // Una Venta puede tener muchos detalles
                .HasForeignKey(dv => dv.Fk_IdVenta)
                .OnDelete(DeleteBehavior.Cascade);  // Eliminar detalles si se elimina la venta

            // Relación de DetalleVenta con Producto
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Producto)  // DetalleVenta tiene una relación con Producto
                .WithMany()  // Un Producto puede estar en muchos detalles de venta
                .HasForeignKey(dv => dv.Fk_IdProducto)
                .OnDelete(DeleteBehavior.Restrict);  // No eliminar Producto si se elimina el detalle

            // Relación entre Ciudad y Departamento: Permitir que la relación sea opcional (clave foránea de tipo string?).
            modelBuilder.Entity<Ciudad>()
                .HasOne(c => c.Departamento)  // Ciudad tiene una relación con Departamento
                .WithMany()  // Un Departamento puede tener muchas Ciudades
                .HasForeignKey(c => c.Fk_IdDepartamento)  // Clave foránea
                .OnDelete(DeleteBehavior.Cascade);  // Elimina las Ciudades al eliminar el Departamento


            // Aplica las configuraciones de las entidades desde el ensamblado actual.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
