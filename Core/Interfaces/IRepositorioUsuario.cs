using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// Repositorio especializado para la entidad Usuario.
    /// </summary>
    public interface IRepositorioUsuario : IRepositorioGenerico<Usuario>
    {
        Task<bool> CrearUsuario(Usuario usuario);
        /// <summary>
        /// Obtiene un usuario por su correo electrónico.
        /// </summary>
        /// <param name="correo">Correo del usuario</param>
        /// <returns>Usuario si existe, null si no</returns>
        Task<Usuario?> ObtenerPorCorreoAsync(string correo);

        /// <summary>
        /// Obtiene un usuario por ID.
        /// </summary>
        /// <param name="id">ID del usuario</param>
        Task<Usuario?> ObtenerPorIdAsync(int id);

        /// <summary>
        /// Restablece la clave de un usuario.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="nuevaClave">Nueva clave generada</param>
        Task RestablecerClaveAsync(int idUsuario, string nuevaClave);
    }
}
