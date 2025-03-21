using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/ICarritoRepository.cs
    public interface ICarritoRepository : IGenericRepository<Carrito>
    {
        // Métodos específicos para 'Carrito' si es necesario.
        Task<IEnumerable<Carrito>> GetCarritoByClienteIdAsync(int clienteId);
    }

}