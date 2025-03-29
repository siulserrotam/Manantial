/*using Core.Entities;
using Core.Interfaces;

namespace Manantial.Application.Services
{
    public class ServicioCategoria
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ServicioCategoria(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria ?? throw new ArgumentNullException(nameof(repositorioCategoria));
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasLasCategoriasAsync()
        {
            return await _repositorioCategoria.ObtenerTodosAsync();
        }

        public async Task<Categoria> ObtenerCategoriaPorIdAsync(int id)
        {
            return await _repositorioCategoria.ObtenerPorIdAsync(id);
        }

        public async Task AgregarCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            await _repositorioCategoria.AgregarAsync(categoria);
        }

        public async Task ActualizarCategoriaAsync(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            await _repositorioCategoria.ActualizarAsync(categoria);
        }

        public async Task EliminarCategoriaAsync(int id)
        {
            var categoria = await _repositorioCategoria.ObtenerPorIdAsync(id);
            if (categoria == null)
                throw new KeyNotFoundException("Categoría no encontrada.");

            await _repositorioCategoria.EliminarAsync(categoria);
        }
    }
}
*/