using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionCiudad : EspecificacionBase<Ciudad>
    {
        public EspecificacionCiudad(Expression<Func<Ciudad, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionCiudad CrearPorDescripcion(string descripcion)
        {
            return new EspecificacionCiudad(ciudad => ciudad.Descripcion.Contains(descripcion));
        }

        public static EspecificacionCiudad CrearPorDepartamento(string departamentoId)
        {
            return new EspecificacionCiudad(ciudad => ciudad.Fk_IdDepartamento == departamentoId);
        }
    }
}
