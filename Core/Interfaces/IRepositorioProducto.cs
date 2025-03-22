using Manantial.Core.Entities; 
using Manantial.Core.Interfaces;

public interface IRepositorioProducto : IRepositorioGenerico<Producto>
{
    Task<IEnumerable<Producto>> ObtenerProductosPorCategoriaAsync(int categoriaId);
    Task<IEnumerable<Producto>> ObtenerProductosActivosAsync();
    
    // Agregar el método ObtenerProductosDisponiblesAsync
    Task<IEnumerable<Producto>> ObtenerProductosDisponiblesAsync();
}
