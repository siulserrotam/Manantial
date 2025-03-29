using Core.Entities;

namespace Core.Interfaces
{
    // Core/Interfaces/IRepositorioCliente.cs
    public interface IRepositorioCliente : IRepositorioGenerico<Cliente>
    {
        // Métodos específicos para 'Cliente' si es necesario.
        Task<Cliente> ObtenerClientePorCorreoAsync(string correo);
    }
}
