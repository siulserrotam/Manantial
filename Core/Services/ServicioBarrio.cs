using Manantial.Core.Entities;
using Manantial.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manantial.Core.Services
{
    public class ServicioBarrio
    {
        private readonly IRepositorioBarrio _repositorioBarrio;

        public ServicioBarrio(IRepositorioBarrio repositorioBarrio)
        {
            _repositorioBarrio = repositorioBarrio;
        }

        // Método para agregar un nuevo barrio
        public async Task<Barrio> AgregarBarrioAsync(Barrio barrio)
        {
            await _repositorioBarrio.AgregarAsync(barrio);
            return barrio;
        }

        // Método para obtener todos los barrios
        public async Task<IEnumerable<Barrio>> ObtenerTodosLosBarriosAsync()
        {
            return await _repositorioBarrio.ObtenerTodosAsync();
        }

        // Método para obtener barrios por ciudad
        public async Task<IEnumerable<Barrio>> ObtenerBarriosPorCiudadAsync(string idCiudad)
        {
            return await _repositorioBarrio.ObtenerPorCiudadAsync(idCiudad);
        }

        // Método para obtener barrios por departamento
        public async Task<IEnumerable<Barrio>> ObtenerBarriosPorDepartamentoAsync(string idDepartamento)
        {
            return await _repositorioBarrio.ObtenerPorDepartamentoAsync(idDepartamento);
        }

        // Método para obtener un barrio por su ID
        public async Task<Barrio> ObtenerBarrioPorIdAsync(string idBarrio)
        {
            return await _repositorioBarrio.ObtenerPorIdAsync(idBarrio);
        }

        // Método para actualizar un barrio
        public async Task<Barrio> ActualizarBarrioAsync(Barrio barrio)
        {
            await _repositorioBarrio.ActualizarAsync(barrio);
            return barrio;
        }

        // Método para eliminar un barrio
        public async Task EliminarBarrioAsync(int idBarrio)
        {
            await _repositorioBarrio.EliminarAsync(idBarrio);
        }
    }
}
