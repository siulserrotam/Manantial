using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioVenta : IRepositorioGenerico<Venta>
    {
        // Método específico para obtener ventas por cliente.
        Task<IEnumerable<Venta>> ObtenerVentasPorIdClienteAsync(int clienteId);
    }
}
