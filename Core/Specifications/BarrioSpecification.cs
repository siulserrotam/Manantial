using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class BarrioSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public BarrioSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}