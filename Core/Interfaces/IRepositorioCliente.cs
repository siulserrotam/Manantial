using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IRepositorioCliente.cs
    public interface IRepositorioCliente : IRepositorioGenerico<Cliente>
    {
        // Métodos específicos para 'Cliente' si es necesario.
        Task<Cliente> ObtenerClientePorCorreoAsync(string correo);
    }
}
