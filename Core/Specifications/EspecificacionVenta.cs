using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionVenta : EspecificacionBase<Venta>
    {
        public EspecificacionVenta(Expression<Func<Venta, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionVenta CrearPorCliente(int clienteId)
        {
            return new EspecificacionVenta(venta => venta.Fk_IdCliente == clienteId);
        }

        public static EspecificacionVenta CrearPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return new EspecificacionVenta(venta => venta.FechaVenta >= fechaInicio && venta.FechaVenta <= fechaFin);
        }
    }
}
