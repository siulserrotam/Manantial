using System;
using System.Linq.Expressions;

namespace Manantial.Core.Specifications
{
    public class UsuarioSpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public UsuarioSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static UsuarioSpecification<T> Create(Expression<Func<T, bool>> criteria)
        {
            return new UsuarioSpecification<T>(criteria);
        }
    }
}