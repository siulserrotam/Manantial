using Manantial.Core.Interfaces;
using System.Linq.Expressions;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task AgregarAsync(T entidad);
        Task<T> ObtenerPorIdAsync(int id);
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(int id);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado);
    }
}