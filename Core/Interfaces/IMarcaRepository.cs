using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/IMarcaRepository.cs
    public interface IMarcaRepository : IGenericRepository<Marca>
    {
        // Métodos específicos para 'Marca' si es necesario.
        Task<IEnumerable<Marca>> GetMarcasActivasAsync();
    }

}