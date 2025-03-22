using Manantial.Core.Entities;
using Manantial.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manantial.Application.Services
{
    public class ServicioCiudad
    {
        private readonly IRepositorioCiudad _repositorioCiudad;

        public ServicioCiudad(IRepositorioCiudad repositorioCiudad)
        {
            _repositorioCiudad = repositorioCiudad;
        }

        // Método para agregar una nueva ciudad
        public async Task<Ciudad> AgregarCiudadAsync(Ciudad ciudad)
        {
            await _repositorioCiudad.AgregarAsync(ciudad);
            return ciudad;
        }

        // Método para obtener todas las ciudades
        public async Task<IEnumerable<Ciudad>> ObtenerTodasLasCiudadesAsync()
        {
            return await _repositorioCiudad.ObtenerTodosAsync();
        }

        // Método para obtener ciudades por departamento
        public async Task<IEnumerable<Ciudad>> ObtenerCiudadesPorDepartamentoAsync(string idDepartamento)
        {
            return await _repositorioCiudad.ObtenerPorDepartamentoAsync(idDepartamento);
        }

        // Método para obtener una ciudad por su ID
        public async Task<Ciudad> ObtenerCiudadPorIdAsync(string idCiudad)
        {
            return await _repositorioCiudad.ObtenerPorIdAsync(idCiudad);
        }

        // Método para actualizar una ciudad
        public async Task<Ciudad> ActualizarCiudadAsync(Ciudad ciudad)
        {
            await _repositorioCiudad.ActualizarAsync(ciudad);
            return ciudad;
        }

        // Método para eliminar una ciudad
        public async Task EliminarCiudadAsync(string idCiudad)
        {
            // Convertir de string a int
            int idCiudadInt = int.Parse(idCiudad);

            // Llamar al repositorio con el id como int
            await _repositorioCiudad.EliminarAsync(idCiudadInt);
        }
    }
}
