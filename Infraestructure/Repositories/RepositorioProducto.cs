using Manantial.Core.Entities;
using Manantial.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Manantial.Infraestructure.Data;
using System.Linq.Expressions;
using Manantial.Core.Specifications;

namespace Manantial.Infraestructure.Repositories
{
    // Implementación de la interfaz IRepositorioProducto
    public class RepositorioProducto : IRepositorioProducto
    {
        // Contexto de base de datos utilizado para interactuar con los datos
        private readonly ContextoTienda _context;

        // Constructor que recibe el contexto de base de datos (ContextoTienda)
        public RepositorioProducto(ContextoTienda context)
        {
            _context = context;
        }

        // Método para obtener todos los productos
        public async Task<IReadOnlyList<Producto>> ObtenerTodosAsync()
        {
            // Devuelve todos los productos, incluyendo la información de categoría y marca
            return await _context.Productos
                .Include(p => p.Categoria)  // Incluye la categoría del producto
                .Include(p => p.Marca)      // Incluye la marca del producto
                .ToListAsync();  // Devuelve la lista completa de productos
        }

        // Método para obtener un producto específico por su ID
        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            // Busca un producto que tenga el mismo ID, incluyendo su categoría y marca
            return await _context.Productos
                .Include(p => p.Categoria)  // Incluye la categoría del producto
                .Include(p => p.Marca)      // Incluye la marca del producto
                .FirstOrDefaultAsync(p => p.Id == id); // Busca el producto por su ID
        }

        // Método para obtener productos por categoría
        public async Task<IReadOnlyList<Producto>> ObtenerProductosPorCategoriaAsync(int categoriaId)
        {
            // Busca los productos que pertenecen a una categoría específica
            return await _context.Productos
                .Where(p => p.Fk_IdCategoria == categoriaId)
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .ToListAsync();  // Devuelve los productos de la categoría
        }

        // Método para obtener productos activos
        public async Task<IReadOnlyList<Producto>> ObtenerProductosActivosAsync()
        {
            // Busca los productos que están activos
            return await _context.Productos
                .Where(p => p.Activo)
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .ToListAsync();  // Devuelve los productos activos
        }

        // Método para obtener productos disponibles (stock > 0 y activos)
        public async Task<IReadOnlyList<Producto>> ObtenerProductosDisponiblesAsync()
        {
            // Busca los productos que tienen stock disponible y están activos
            return await _context.Productos
                .Where(p => p.Stock > 0 && p.Activo)
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .ToListAsync();  // Devuelve los productos disponibles
        }

        // Implementación del método ListarAsync que utiliza la especificación
        public async Task<IReadOnlyList<Producto>> ListarAsync(EspecificacionProductosConCategoriaYMarca especificacion)
        {
            // Aplica la especificación de la consulta con las inclusiones de categoría y marca
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .Where(especificacion.Criterio)  // Aplica los filtros definidos en la especificación
                .ToListAsync();  // Ejecuta la consulta y devuelve la lista de productos
        }

        Task<IEnumerable<Producto>> IRepositorioProducto.ObtenerProductosPorCategoriaAsync(int categoriaId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producto>> IRepositorioProducto.ObtenerProductosActivosAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producto>> IRepositorioProducto.ObtenerProductosDisponiblesAsync()
        {
            throw new NotImplementedException();
        }

        public Task AgregarAsync(Producto entidad)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producto>> IRepositorioGenerico<Producto>.ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task ActualizarAsync(Producto entidad)
        {
            throw new NotImplementedException();
        }

        public Task EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> BuscarAsync(Expression<Func<Producto, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}
