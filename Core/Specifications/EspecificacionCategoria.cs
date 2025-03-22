using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionCategoria : EspecificacionBase<Categoria>
    {
        public EspecificacionCategoria(Expression<Func<Categoria, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionCategoria CrearPorDescripcion(string descripcion)
        {
            return new EspecificacionCategoria(categoria => categoria.Descripcion.Contains(descripcion));
        }

        public static EspecificacionCategoria CrearPorEstado(bool activo)
        {
            return new EspecificacionCategoria(categoria => categoria.Activo == activo);
        }
    }
}
