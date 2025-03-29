using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Core.Interfaces{
    public interface IRepositorioProducto : IRepositorioGenerico<Producto>
    {
        // Método para obtener un producto por su ID
        Task<Producto> ObtenerProductoPorIdAsync(int id);

        // Método para obtener todos los productos
        Task<IReadOnlyList<Producto>> ObtenerProductosAsync();

        // Método para obtener un producto con una especificación
        Task<Producto> ObtenerProductoConEspecificacionAsync(IEspecificacion<Producto> spec);

        // Método para obtener productos filtrados por categoría
        Task<IReadOnlyList<Producto>> ObtenerProductosPorCategoriaAsync(int Fk_IdCategoria);

        // Método para obtener productos filtrados por marca
        Task<IReadOnlyList<Producto>> ObtenerProductosPorMarcaAsync(int Fk_IdMarca);

        // Método para obtener una lista de productos basada en una especificación
        Task<IReadOnlyList<Producto>> ListarProductosAsync(IEspecificacion<Producto> spec);
    }
}