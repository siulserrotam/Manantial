using System.Linq.Expressions;

namespace Manantial.Core.Interfaces
{
    public interface IEspecificacion<T>
    {
        // Define criterios de consulta y predicados que se aplican a la entidad T
        Expression<Func<T, bool>> Criterio { get; }
        List<Expression<Func<T, object>>> Incluir { get; }
        Expression<Func<T, object>> OrdenarPor { get; }
        Expression<Func<T, object>> OrdenarPorDescendente { get; }
        int Tomar { get; }
        int Omitir { get; }
        bool EsPaginacionHabilitada { get; }
        object Includes { get; }
    }
}
