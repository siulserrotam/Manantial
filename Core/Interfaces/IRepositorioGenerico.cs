using Core.Entities;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepositorioGenerico<T> where T : EntidadBase
    {
        Task AgregarAsync(T entidad);
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(int id);

        Task<T> ObtenerPorIdAsync(int id);
        Task<IReadOnlyList<T>> ObtenerTodosAsync();
        Task<IReadOnlyList<T>> BuscarAsync(Expression<Func<T, bool>> predicado);

        Task<int> ContarPorEspecificacionAsync(IEspecificacion<T> spec);
        Task<T> ObtenerPorEspecificacionAsync(IEspecificacion<T> spec);
        Task<IReadOnlyList<T>> ListarPorEspecificacionAsync(IEspecificacion<T> spec);
    }
}
