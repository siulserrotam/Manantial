using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioCategoria : IRepositorioGenerico<Categoria>
    {
        Task EliminarAsync(Categoria categoria);
        Task<IEnumerable<Categoria>> ObtenerCategoriasActivasAsync();
    }
}