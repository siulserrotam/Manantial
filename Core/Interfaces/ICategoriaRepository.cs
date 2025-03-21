using Manantial.Core.Entities;

namespace Manantial.Core.Interfaces
{
    // Core/Interfaces/ICategoriaRepository.cs
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        // Aquí puedes agregar métodos específicos para 'Categoria' si es necesario.
        Task<IEnumerable<Categoria>> GetCategoriasActivasAsync();
    }

}