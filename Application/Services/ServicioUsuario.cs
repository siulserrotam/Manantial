using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicioUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private static readonly Random _random = new();

        public ServicioUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            return await _repositorioUsuario.CrearUsuario(usuario);
        }

        public async Task AgregarUsuario(Usuario usuario)
        {
            await _repositorioUsuario.AgregarAsync(usuario);
        }

        public async Task<Usuario?> ObtenerUsuarioPorCorreo(string correo)
        {
            return await _repositorioUsuario.ObtenerPorCorreoAsync(correo);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return await _repositorioUsuario.ObtenerTodosAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorId(int id)
        {
            return await _repositorioUsuario.ObtenerPorIdAsync(id);
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            var usuarioExistente = await _repositorioUsuario.ObtenerPorIdAsync(usuario.Id);
            if (usuarioExistente == null)
                return false;

            await _repositorioUsuario.ActualizarAsync(usuario);
            return true;
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            var usuario = await _repositorioUsuario.ObtenerPorIdAsync(id);
            if (usuario == null || usuario.Id == 1)
                return false;

            await _repositorioUsuario.EliminarAsync(id);
            return true;
        }

        public async Task<string?> RestablecerClave(int idUsuario)
        {
            var usuario = await _repositorioUsuario.ObtenerPorIdAsync(idUsuario);
            if (usuario == null)
                return null;

            var nuevaClave = GenerarClaveAleatoria();
            await _repositorioUsuario.RestablecerClaveAsync(idUsuario, nuevaClave);
            return nuevaClave;
        }

        private string GenerarClaveAleatoria()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(caracteres, 8)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
