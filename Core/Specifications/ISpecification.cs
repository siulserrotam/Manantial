using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public interface ISpecification<T>
{
    // Define criterios de consulta y predicados que se aplican a la entidad T
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
}


}