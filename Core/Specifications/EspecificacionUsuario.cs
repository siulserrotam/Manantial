using System;
using System.Linq.Expressions;
using Manantial.Core.Entities;

namespace Manantial.Core.Specifications
{
    public class EspecificacionUsuario : EspecificacionBase<Usuario>
    {
        public EspecificacionUsuario(Expression<Func<Usuario, bool>> criterio)
            : base(criterio) { }

        public static EspecificacionUsuario CrearPorCorreo(string correo)
        {
            return new EspecificacionUsuario(usuario => usuario.Correo == correo);
        }

        public static EspecificacionUsuario CrearPorEstado(bool activo)
        {
            return new EspecificacionUsuario(usuario => usuario.Activo == activo);
        }

        public static EspecificacionUsuario CrearPorRestablecer(bool restablecer)
        {
            return new EspecificacionUsuario(usuario => usuario.Restablecer == restablecer);
        }
    }
}
