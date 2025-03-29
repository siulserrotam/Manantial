using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class ServicioCliente
    {
        private readonly IRepositorioCliente _clienteRepository;

        public ServicioCliente(IRepositorioCliente clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodosLosClientesAsync()
        {
            return await _clienteRepository.ObtenerTodosAsync();
        }

        public async Task<Cliente> ObtenerClientePorIdAsync(int id)
        {
            return await _clienteRepository.ObtenerPorIdAsync(id);
        }

        public async Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            return cliente;  //await _clienteRepository.AgregarAsync(cliente);
        }

        public async Task<Cliente> ActualizarClienteAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            return cliente; //await _clienteRepository.ActualizarAsync(cliente);
        }
        /*
        public async Task EliminarClienteAsync(int id)
        {
            await _clienteRepository.EliminarAsync(id);
        }*/
    }
}
