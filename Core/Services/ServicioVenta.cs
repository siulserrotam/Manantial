using Manantial.Core.Entities;
using Manantial.Core.Interfaces;
using System.Threading.Tasks;

namespace Manantial.Core.Services
{
    public class ServicioVenta
    {
        private readonly IRepositorioVenta _repositorioVenta;
        private readonly IRepositorioProducto _repositorioProducto; // Repositorio de productos si es necesario

        public ServicioVenta(IRepositorioVenta repositorioVenta, IRepositorioProducto repositorioProducto)
        {
            _repositorioVenta = repositorioVenta;
            _repositorioProducto = repositorioProducto;
        }

        public async Task<Venta> RealizarVentaAsync(Venta venta)
        {
            // Lógica de negocio: Validar productos, actualizar inventarios, calcular monto total, etc.
            var productosDisponibles = await _repositorioProducto.ObtenerProductosDisponiblesAsync();
            if (!productosDisponibles.Any(p => p.Id == venta.Fk_IdProducto))
            {
                throw new Exception("Producto no disponible.");
            }

            // Ejemplo de actualización de inventario (si es necesario)
            var producto = await _repositorioProducto.ObtenerPorIdAsync(venta.Fk_IdProducto);
            if (producto.Cantidad < venta.TotalProducto)
            {
                throw new Exception("No hay suficiente stock.");
            }

            // Crear la venta
            venta.FechaVenta = DateTime.Now;
            venta.MontoTotal = CalcularMontoTotal(venta);

            // Guardar la venta en el repositorio
            await _repositorioVenta.AgregarAsync(venta);

            // Devolver la venta generada
            return venta;
        }

        private decimal CalcularMontoTotal(Venta venta)
        {
            // Ejemplo simple de cálculo de monto total (esto depende de tu lógica de negocio)
            var producto = _repositorioProducto.ObtenerPorIdAsync(venta.Fk_IdProducto).Result;
            return producto.Precio * venta.TotalProducto;
        }
    }
}
