using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionCarrito : EspecificacionBase<Carrito>
    {
        public EspecificacionCarrito(Expression<Func<Carrito, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionCarrito CrearPorCliente(int clienteId)
        {
            return new EspecificacionCarrito(carrito => carrito.Fk_IdCliente == clienteId);
        }

        public static EspecificacionCarrito CrearPorProducto(int productoId)
        {
            return new EspecificacionCarrito(carrito => carrito.Fk_IdProducto == productoId);
        }
    }
}
