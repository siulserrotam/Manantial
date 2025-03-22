using Manantial.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioDepartamento : IRepositorioGenerico<Departamento>
    {
        Task<IEnumerable<Departamento>> ObtenerTodosAsync();
        Task<Departamento> ObtenerPorIdAsync(string idDepartamento);
    }
}
