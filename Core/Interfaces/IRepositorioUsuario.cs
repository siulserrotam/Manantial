using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioGenerico<Usuario>
    {
        // Método para obtener un usuario por su correo
        Task<Usuario> ObtenerPorCorreoAsync(string correo);

        // Método para restablecer la clave de un usuario
        Task RestablecerClaveAsync(int idUsuario, string nuevaClave);
    }
}
