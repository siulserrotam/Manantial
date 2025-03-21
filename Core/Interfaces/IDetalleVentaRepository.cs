using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IDetalleVentaRepository.cs
    public interface IDetalleVentaRepository : IGenericRepository<DetalleVenta>
    {
        // Métodos específicos para 'DetalleVenta' si es necesario.
        Task<IEnumerable<DetalleVenta>> GetDetallesByVentaIdAsync(int ventaId);
    }
}