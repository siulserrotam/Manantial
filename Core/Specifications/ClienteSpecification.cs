using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class ClienteSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public ClienteSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static ClienteSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new ClienteSpecification<T>(criteria);
        }
    }
}