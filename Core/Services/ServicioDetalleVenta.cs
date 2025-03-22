using Manantial.Core.Entities;
using Manantial.Core.Interfaces;
using System.Threading.Tasks;

namespace Manantial.Core.Services
{
    public class ServicioDetalleVenta
    {
        private readonly IRepositorioDetalleVenta _repositorioDetalleVenta;
        private readonly IRepositorioProducto _repositorioProducto;

        public ServicioDetalleVenta(IRepositorioDetalleVenta repositorioDetalleVenta, IRepositorioProducto repositorioProducto)
        {
            _repositorioDetalleVenta = repositorioDetalleVenta;
            _repositorioProducto = repositorioProducto;
        }

        public async Task<DetalleVenta> CrearDetalleVentaAsync(DetalleVenta detalleVenta)
        {
            // Lógica de negocio: Validación y cálculo del total de la venta
            var producto = await _repositorioProducto.ObtenerPorIdAsync(detalleVenta.Fk_IdProducto);
            if (producto == null)
            {
                throw new Exception("Producto no encontrado.");
            }

            // Calcular el total del detalle de la venta
            detalleVenta.Total = CalcularTotal(detalleVenta, producto);

            // Guardar el detalle de venta
            await _repositorioDetalleVenta.AgregarAsync(detalleVenta);

            return detalleVenta;
        }

        private decimal CalcularTotal(DetalleVenta detalleVenta, Producto producto)
        {
            // Cálculo del total, por ejemplo, multiplicando la cantidad por el precio del producto
            return detalleVenta.Cantidad * producto.Precio;
        }
    }
}
