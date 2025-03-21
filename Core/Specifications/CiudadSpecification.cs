using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class CiudadSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public CiudadSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static CiudadSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new CiudadSpecification<T>(criteria);
        }
    }
}