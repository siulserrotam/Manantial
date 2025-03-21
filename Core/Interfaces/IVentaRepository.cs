using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IVentaRepository.cs
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        // Métodos específicos para 'Venta' si es necesario.
        Task<IEnumerable<Venta>> GetVentasByClienteIdAsync(int clienteId);
    }
}