using Manantial.Core.Entities;
using Manantial.Core.Interfaces;

namespace Manantial.Application.Services
{
    public class ServicioProducto
    {
        private readonly IRepositorioProducto _productoRepository;

        public ServicioProducto(IRepositorioProducto productoRepository)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosLosProductosAsync()
        {
            return await _productoRepository.ObtenerTodosAsync();
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _productoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Producto> CrearProductoAsync(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            return producto; //await _productoRepository.AgregarAsync(producto);
        }

        public async Task<Producto> ActualizarProductoAsync(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            return producto; //await _productoRepository.ActualizarAsync(producto);
        }

        public async Task EliminarProductoAsync(int id)
        {
            await _productoRepository.EliminarAsync(id);
        }
    }
}
