using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class DetalleVentaSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public DetalleVentaSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static DetalleVentaSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new DetalleVentaSpecification<T>(criteria);
        }
    }
}