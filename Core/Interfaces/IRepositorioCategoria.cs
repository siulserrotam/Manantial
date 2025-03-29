using Core.Entities;

namespace Core.Interfaces
{
    public interface IRepositorioCategoria : IRepositorioGenerico<Categoria>
    {
        Task EliminarAsync(Categoria categoria);
        Task<IEnumerable<Categoria>> ObtenerCategoriasActivasAsync();
    }
}