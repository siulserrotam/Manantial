using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IEspecificacion<T>
    {
        // Criterios de filtrado
        Expression<Func<T, bool>> Criterio { get; }

        // Incluye para carga impaciente
        List<Expression<Func<T, object>>> Incluir { get; }
    }
}
