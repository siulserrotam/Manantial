using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionMarca : EspecificacionBase<Marca>
    {
        public EspecificacionMarca(Expression<Func<Marca, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionMarca CrearPorDescripcion(string descripcion)
        {
            return new EspecificacionMarca(marca => marca.Descripcion.Contains(descripcion));
        }

        public static EspecificacionMarca CrearPorEstado(bool activo)
        {
            return new EspecificacionMarca(marca => marca.Activo == activo);
        }
    }
}
