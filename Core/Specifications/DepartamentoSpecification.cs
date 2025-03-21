using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class DepartamentoSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public DepartamentoSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static DepartamentoSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new DepartamentoSpecification<T>(criteria);
        }
    }
}