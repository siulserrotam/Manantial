using Manantial.Core.Entities; 
using Manantial.Core.Interfaces;
public interface IRepositorioProducto : IRepositorioGenerico<Producto>
{
    // Método para obtener un producto por su ID
    Task<Producto> ObtenerProductoPorIdAsync(int id);

    // Método para obtener todos los productos
    Task<IReadOnlyList<Producto>> ObtenerProductosAsync();

    // Método para obtener un producto con una especificación

    Task<Producto> ObtenerProductoConEspecificacionAsync(IEspecificacion<Producto> spec);

    // Método para obtener productos por categoría
    Task<IReadOnlyList<Producto>> ObtenerProductosPorCategoriaAsync(int ID);

    // Método para obtener productos por marca
    Task<IReadOnlyList<Producto>> ObtenerProductosPorMarcaAsync(int ID);

    // Método para obtener productos activos
    Task<IReadOnlyList<Producto>> ObtenerProductosActivosAsync();

    // Método para obtener productos disponibles
    Task<IReadOnlyList<Producto>> ObtenerProductosDisponiblesAsync();

    // Método para obtener una lista de productos basada en una especificación
    Task<IReadOnlyList<Producto>> ListarProductosAsync(IEspecificacion<Producto> spec);
}
