using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionDepartamento : EspecificacionBase<Departamento>
    {
        public EspecificacionDepartamento(Expression<Func<Departamento, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionDepartamento CrearPorDescripcion(string descripcion)
        {
            return new EspecificacionDepartamento(departamento => departamento.Descripcion.Contains(descripcion));
        }
    }
}
