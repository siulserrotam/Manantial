using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionProductosConCategoriaYMarca : EspecificacionBase<Producto>
    {
        public EspecificacionProductosConCategoriaYMarca()
        {
            AgregarIncluir(p => p.Categoria);
            AgregarIncluir(p => p.Marca);
        }

        private void AddInclude(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        public EspecificacionProductosConCategoriaYMarca(Expression<Func<Producto, bool>> criteriO)
            : base(criteriO)
        {
            AgregarIncluir(p => p.Categoria);
            AgregarIncluir(p => p.Marca);
        }
    }
}