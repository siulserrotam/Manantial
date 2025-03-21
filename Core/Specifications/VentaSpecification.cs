using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class VentaSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; }

        public VentaSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static VentaSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new VentaSpecification<T>(criteria);
        }
    }
}