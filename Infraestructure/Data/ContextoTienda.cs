using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class ContextoTienda : DbContext
    {
        // Constructor con parámetros (usado normalmente en producción)
        public ContextoTienda(DbContextOptions<ContextoTienda> options) : base(options)
        {
        }

        // Constructor sin parámetros (útil para herramientas de scaffolding o pruebas)
        public ContextoTienda()
        {
        }

        // DbSet: tablas de la base de datos
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Claves primarias
            modelBuilder.Entity<Departamento>().HasKey(d => d.IdDepartamento);
            modelBuilder.Entity<Ciudad>().HasKey(c => c.IdCiudad);
            modelBuilder.Entity<Barrio>().HasKey(b => b.IdBarrio);
            modelBuilder.Entity<Carrito>().HasKey(c => c.IdCarrito);
            modelBuilder.Entity<DetalleVenta>().HasKey(dv => dv.IdDetalleVenta);

            // Relaciones
            modelBuilder.Entity<Barrio>()
                .HasOne(b => b.Departamento)
                .WithMany()
                .HasForeignKey(b => b.Fk_IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Barrio>()
                .HasOne(b => b.Ciudad)
                .WithMany()
                .HasForeignKey(b => b.Fk_IdCiudad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Venta)
                .WithMany()
                .HasForeignKey(dv => dv.Fk_IdVenta)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Producto)
                .WithMany()
                .HasForeignKey(dv => dv.Fk_IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ciudad>()
                .HasOne(c => c.Departamento)
                .WithMany()
                .HasForeignKey(c => c.Fk_IdDepartamento)
                .OnDelete(DeleteBehavior.Cascade);

            // Precisión decimal
            modelBuilder.Entity<DetalleVenta>()
                .Property(d => d.Total)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Venta>()
                .Property(v => v.MontoTotal)
                .HasColumnType("decimal(18,2)");

            // Aplicar configuración adicional si existe
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // Si lo deseas, puedes sobrescribir OnConfiguring para pruebas sin inyección de dependencias.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Solo para pruebas o uso sin DI
                optionsBuilder.UseSqlServer("Server=localhost;Database=TiendaDb;Trusted_Connection=True;");
            }
        }
    }
}
