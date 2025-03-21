using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IProductoRepository.cs
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        // Métodos específicos para 'Producto' si es necesario.
        Task<IEnumerable<Producto>> GetProductosPorCategoriaAsync(int categoriaId);
        Task<IEnumerable<Producto>> GetProductosActivosAsync();
    }

}