using Core.Entities;
using Core.Interfaces;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepositorioGenerico<T> where T : EntidadBase
    {
        // Agrega una nueva entidad de forma asincrónica
        // Task AgregarAsync(T entidad);

        // Actualiza una entidad existente
        // Task ActualizarAsync(T entidad);

        // Elimina una entidad por su ID
        // Task EliminarAsync(int id);
        
        // Obtiene una entidad por su ID
        Task<T> ObtenerPorIdAsync(int id);

        // Obtiene todas las entidades de tipo T
        Task<IReadOnlyList<T>> ObtenerTodosAsync();
        
        // Busca entidades que coincidan con una condición
        // Task<IReadOnlyList<T>> BuscarAsync(Expression<Func<T, bool>> predicado);

        // Cuenta cuántos elementos cumplen con una especificación
        // Task<int> ContarPorEspecificacionAsync(IEspecificacion<T> spec);
        // Obtiene una entidad basada en una especificación

        Task<T> ObtenerPorEspecificacionAsync(IEspecificacion<T> spec);
        
        // Obtiene una lista de entidades basada en una especificación
        Task<IReadOnlyList<T>> ListarPorEspecificacionAsync(IEspecificacion<T> spec);

    }
}
