using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IUsuarioRepository.cs
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        // Métodos específicos para 'Usuario' si es necesario.
        Task<Usuario> GetUsuarioByCorreoAsync(string correo);
    }
}