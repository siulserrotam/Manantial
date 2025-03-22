using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionBarrio : EspecificacionBase<Barrio>
    {
        public EspecificacionBarrio(Expression<Func<Barrio, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionBarrio CrearPorDescripcion(string descripcion)
        {
            return new EspecificacionBarrio(barrio => barrio.Descripcion.Contains(descripcion));
        }

        public static EspecificacionBarrio CrearPorCiudad(string ciudadId)
        {
            return new EspecificacionBarrio(barrio => barrio.Fk_IdCiudad == ciudadId);
        }
    }
}
