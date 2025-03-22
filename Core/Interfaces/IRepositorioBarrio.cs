using Manantial.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manantial.Core.Interfaces
{
    public interface IRepositorioBarrio : IRepositorioGenerico<Barrio>
    {
        Task<IEnumerable<Barrio>> ObtenerPorCiudadAsync(string idCiudad);
        Task<Barrio> ObtenerPorIdAsync(string idBarrio);
        Task<IEnumerable<Barrio>> ObtenerPorDepartamentoAsync(string idDepartamento);
    }
}
