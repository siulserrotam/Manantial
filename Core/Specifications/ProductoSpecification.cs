using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class ProductoSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public ProductoSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static ProductoSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new ProductoSpecification<T>(criteria);
        }
    }
}