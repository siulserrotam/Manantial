using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IClienteRepository.cs
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        // Métodos específicos para 'Cliente' si es necesario.
        Task<Cliente> GetClienteByCorreoAsync(string correo);
    }
}