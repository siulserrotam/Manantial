/*using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicioDepartamento
    {
        private readonly IRepositorioDepartamento _repositorioDepartamento;

        public ServicioDepartamento(IRepositorioDepartamento repositorioDepartamento)
        {
            _repositorioDepartamento = repositorioDepartamento;
        }

        // Método para agregar un nuevo departamento
        public async Task<Departamento> AgregarDepartamentoAsync(Departamento departamento)
        {
            await _repositorioDepartamento.AgregarAsync(departamento);
            return departamento;
        }

        // Método para obtener todos los departamentos
        public async Task<IEnumerable<Departamento>> ObtenerTodosDepartamentosAsync()
        {
            return await _repositorioDepartamento.ObtenerTodosAsync();
        }

        // Método para obtener un departamento por su ID
        public async Task<Departamento> ObtenerDepartamentoPorIdAsync(string idDepartamento)
        {
            return await _repositorioDepartamento.ObtenerPorIdAsync(idDepartamento);
        }

        // Método para actualizar un departamento
        public async Task<Departamento> ActualizarDepartamentoAsync(Departamento departamento)
        {
            await _repositorioDepartamento.ActualizarAsync(departamento);
            return departamento;
        }

        // Método para eliminar un departamento
        public async Task EliminarDepartamentoAsync(string idDepartamento)
        {
            // Convertir de string a int
            int idDepartamentoInt = int.Parse(idDepartamento);

            // Llamar al repositorio con el id como int
            await _repositorioDepartamento.EliminarAsync(idDepartamentoInt);
        }
    }
}
*/