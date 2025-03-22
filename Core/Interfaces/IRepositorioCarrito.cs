using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioCarrito : IRepositorioGenerico<Carrito>
    {
        // Métodos específicos para 'Carrito'.
        Task<IEnumerable<Carrito>> ObtenerCarritoPorIdClienteAsync(int clienteId);
    }
}