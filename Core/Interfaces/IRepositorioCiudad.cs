using Manantial.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioCiudad : IRepositorioGenerico<Ciudad>
    {
        Task<IEnumerable<Ciudad>> ObtenerPorDepartamentoAsync(string idDepartamento);
        Task<Ciudad> ObtenerPorIdAsync(string idCiudad);
    }
}
