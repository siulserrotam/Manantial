using Manantial.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Manantial.Infraestructure.Data
{
    public class ContextoTienda : DbContext
    {
        // Constructor que recibe las opciones de configuración para el DbContext
        public ContextoTienda(DbContextOptions<ContextoTienda> options) : base(options)
        {
        }

        // Definimos las propiedades DbSet que representan las tablas en la base de datos
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

        // Método OnModelCreating para configurar las entidades y sus relaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Llama al método base para la configuración predeterminada

            // Configuración explícita para la entidad Barrio
            modelBuilder.Entity<Barrio>().HasKey(b => b.IdBarrio);  // Configurar IdBarrio como la clave primaria

            // Configuración de la relación entre Barrio y Departamento
            modelBuilder.Entity<Barrio>()
                .HasOne(b => b.Departamento)  // Barrio tiene una relación con Departamento
                .WithMany()                   // Un Departamento puede tener muchos Barrios
                .HasForeignKey(b => b.Fk_IdDepartamento)  // Clave foránea
                .OnDelete(DeleteBehavior.Cascade);  // Si se elimina un Departamento, se eliminan los barrios asociados

            // Configuración de la relación entre Barrio y Ciudad
            modelBuilder.Entity<Barrio>()
                .HasOne(b => b.Ciudad)  // Barrio tiene una relación con Ciudad
                .WithMany()              // Una Ciudad puede tener muchos Barrios
                .HasForeignKey(b => b.Fk_IdCiudad)  // Clave foránea
                .OnDelete(DeleteBehavior.Cascade);  // Si se elimina una Ciudad, se eliminan los barrios asociados

            // Configuración explícita para la entidad Ciudad
            modelBuilder.Entity<Ciudad>().HasKey(c => c.IdCiudad);  // Configurar IdCiudad como la clave primaria

            // Configuración explícita para la entidad Departamento
            modelBuilder.Entity<Departamento>().HasKey(d => d.IdDepartamento);  // Configurar IdDepartamento como la clave primaria

            // Configuración explícita para la entidad DetalleVenta
            modelBuilder.Entity<DetalleVenta>().HasKey(dv => dv.IdDetalleVenta);  // Configurar IdDetalleVenta como la clave primaria

            // Configuración de la entidad Carrito y sus relaciones
            modelBuilder.Entity<Carrito>().HasKey(c => c.IdCarrito);  // Configurar IdCarrito como clave primaria

            // Relación Carrito -> Cliente (un carrito tiene un cliente)
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Cliente)
                .WithMany()  // Un cliente puede tener muchos carritos
                .HasForeignKey(c => c.Fk_IdCliente)
                .OnDelete(DeleteBehavior.Cascade);  // Eliminar carritos cuando se elimine un cliente

            // Relación Carrito -> Producto (un carrito tiene un producto)
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Producto)
                .WithMany()  // Un producto puede estar en muchos carritos
                .HasForeignKey(c => c.Fk_IdProducto)
                .OnDelete(DeleteBehavior.SetNull);  // Si se elimina el producto, se establece Fk_IdProducto a null

            // Configuración de la relación entre Venta y Cliente
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany()  // Un cliente puede tener muchas ventas
                .HasForeignKey(v => v.Fk_IdCliente)
                .OnDelete(DeleteBehavior.Restrict);  // Mantener ventas aunque se elimine un cliente

            // Configuración de la relación entre DetalleVenta y Venta
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Venta)
                .WithMany()  // Una venta puede tener muchos detalles de venta
                .HasForeignKey(dv => dv.Fk_IdVenta)
                .OnDelete(DeleteBehavior.Cascade);  // Eliminar detalles de venta cuando se elimina una venta

            // Configuración de la relación entre DetalleVenta y Producto
            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Producto)
                .WithMany()  // Un producto puede estar en muchos detalles de venta
                .HasForeignKey(dv => dv.Fk_IdProducto)
                .OnDelete(DeleteBehavior.Restrict);  // No eliminar productos cuando se elimine el detalle de venta

            // Puedes agregar más configuraciones si es necesario para otras entidades
        }
    }
}
