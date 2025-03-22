using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionCliente : EspecificacionBase<Cliente>
    {
        public EspecificacionCliente(Expression<Func<Cliente, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionCliente CrearPorCorreo(string correo)
        {
            return new EspecificacionCliente(cliente => cliente.Correo == correo);
        }

        public static EspecificacionCliente CrearPorRestablecer(bool restablecer)
        {
            return new EspecificacionCliente(cliente => cliente.Restablecer == restablecer);
        }

        public static EspecificacionCliente CrearPorNombres(string nombres)
        {
            return new EspecificacionCliente(cliente => cliente.Nombres.Contains(nombres));
        }
    }
}
