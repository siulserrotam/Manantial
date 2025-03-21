using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class CategoriaSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public CategoriaSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static CategoriaSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new CategoriaSpecification<T>(criteria);
        }
    }
}