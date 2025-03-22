using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionProducto : EspecificacionBase<Producto>
    {
        public EspecificacionProducto(Expression<Func<Producto, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionProducto CrearPorCategoria(int categoriaId)
        {
            return new EspecificacionProducto(producto => producto.Fk_IdCategoria == categoriaId);
        }

        public static EspecificacionProducto CrearPorMarca(int marcaId)
        {
            return new EspecificacionProducto(producto => producto.Fk_IdMarca == marcaId);
        }

        public static EspecificacionProducto CrearPorPrecio(decimal precioMin, decimal precioMax)
        {
            return new EspecificacionProducto(producto => producto.Precio >= precioMin && producto.Precio <= precioMax);
        }

        public static EspecificacionProducto CrearPorEstado(bool activo)
        {
            return new EspecificacionProducto(producto => producto.Activo == activo);
        }
    }
}
