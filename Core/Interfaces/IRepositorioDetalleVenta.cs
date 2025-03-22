using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioDetalleVenta : IRepositorioGenerico<DetalleVenta>
    {
        // Método específico para obtener detalles de venta por el Id de la venta
        Task<IEnumerable<DetalleVenta>> ObtenerDetallesPorIdVentaAsync(int idVenta);
    }
}
