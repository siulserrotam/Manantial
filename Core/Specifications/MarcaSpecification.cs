using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class MarcaSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public MarcaSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static MarcaSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new MarcaSpecification<T>(criteria);
        }
    }
}