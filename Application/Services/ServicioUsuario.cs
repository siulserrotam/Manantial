using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServicioUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IServicioCorreo _servicioCorreo; // Interfaz para el servicio de correo

        public ServicioUsuario(IRepositorioUsuario repositorioUsuario, IServicioCorreo servicioCorreo)
        {
            _repositorioUsuario = repositorioUsuario;
            _servicioCorreo = servicioCorreo;
        }

        // Método para crear un nuevo usuario
        public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
        {
            // Lógica de negocio: Validar que el correo no esté en uso
            var usuarioExistente = await _repositorioUsuario.ObtenerPorCorreoAsync(usuario.Correo);
            if (usuarioExistente != null)
            {
                throw new Exception("El correo electrónico ya está en uso.");
            }

            // Agregar el nuevo usuario
            await _repositorioUsuario.AgregarAsync(usuario);

            return usuario;
        }

        // Método para restablecer la contraseña de un usuario
        public async Task RestablecerClaveAsync(int idUsuario)
        {
            // Obtener el usuario por id
            var usuario = await _repositorioUsuario.ObtenerPorIdAsync(idUsuario);
            if (usuario == null)
            {
                throw new Exception("El usuario no existe.");
            }

            // Generar una nueva clave aleatoria
            var nuevaClave = GenerarClaveAleatoria();

            // Restablecer la clave en el repositorio
            await _repositorioUsuario.RestablecerClaveAsync(idUsuario, nuevaClave);

            // Enviar la nueva clave al correo registrado del usuario
            var asunto = "Restablecimiento de tu clave de acceso";
            var cuerpo = $"Hola {usuario.Nombres},\n\nTu nueva clave de acceso es: {nuevaClave}\n\nPor favor, cámbiala en tu siguiente inicio de sesión.";

            await _servicioCorreo.EnviarCorreoAsync(usuario.Correo, asunto, cuerpo);
        }

        // Método para generar una clave aleatoria (por ejemplo, de 8 caracteres)
        private string GenerarClaveAleatoria()
        {
            var random = new Random();
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] clave = new char[8]; // Generamos una clave de 8 caracteres

            for (int i = 0; i < clave.Length; i++)
            {
                clave[i] = caracteres[random.Next(caracteres.Length)];
            }

            return new string(clave);
        }
    }
}
