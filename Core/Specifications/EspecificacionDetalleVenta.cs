using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionDetalleVenta : EspecificacionBase<DetalleVenta>
    {
        public EspecificacionDetalleVenta(Expression<Func<DetalleVenta, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionDetalleVenta CrearPorVenta(int ventaId)
        {
            return new EspecificacionDetalleVenta(detalleVenta => detalleVenta.Fk_IdVenta == ventaId);
        }

        public static EspecificacionDetalleVenta CrearPorProducto(int productoId)
        {
            return new EspecificacionDetalleVenta(detalleVenta => detalleVenta.Fk_IdProducto == productoId);
        }
    }
}
