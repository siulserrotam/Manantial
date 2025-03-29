using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
public interface IRepositorioProducto : IRepositorioGenerico<Producto>
{
   
    // Método para obtener un producto por su ID
    Task<Producto> ObtenerProductoPorIdAsync(int id);

    // Método para obtener todos los productos
    Task<IReadOnlyList<Producto>> ObtenerProductosAsync();

    // Método para obtener un producto con una especificación
    Task<Producto> ObtenerProductoConEspecificacionAsync(IEspecificacion<Producto> spec);

    // Método para obtener productos por categoría
    Task<IReadOnlyList<Categoria>> ObtenerProductosPorCategoriaAsync();

    // Método para obtener productos por marca
    Task<IReadOnlyList<Marca>> ObtenerProductosPorMarcaAsync();

    // Método para obtener una lista de productos basada en una especificación
    Task<IReadOnlyList<Producto>> ListarProductosAsync(EspecificacionProductosConCategoriaYMarca spec);

}
