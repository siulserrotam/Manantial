using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IRepositorioMarca.cs
    public interface IRepositorioMarca : IRepositorioGenerico<Marca>
    {
        // Métodos específicos para 'Marca' si es necesario.
        Task<IEnumerable<Marca>> ObtenerMarcasActivasAsync();
    }
}