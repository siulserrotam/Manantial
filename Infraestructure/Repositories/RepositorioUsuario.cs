using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly ContextoTienda _context;

    public RepositorioUsuario(ContextoTienda context)
    {
        _context = context;
    }

    // Crea un nuevo usuario y lo guarda en la base de datos
    public async Task<bool> CrearUsuario(Usuario usuario)
    {
    _context.Usuarios.Add(usuario);
    return await _context.SaveChangesAsync() > 0;
    }

    // Agrega un nuevo usuario
    public async Task AgregarAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await GuardarCambiosAsync();
    }

    // Obtiene un usuario por su correo
    public async Task<Usuario?> ObtenerPorCorreoAsync(string correo)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Correo == correo);
    }

    // Obtiene todos los usuarios
    public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    // Obtiene un usuario por ID
    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    // Actualiza un usuario existente
    public async Task ActualizarAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await GuardarCambiosAsync();
    }

    // Elimina un usuario, con validación para no eliminar al administrador (id = 1)
    public async Task EliminarAsync(int id)
    {
        if (id == 1)
        {
            throw new InvalidOperationException("No se puede eliminar el usuario administrador.");
        }

        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await GuardarCambiosAsync();
        }
    }

    // Restablece la clave del usuario
    public async Task RestablecerClaveAsync(int idUsuario, string nuevaClave)
    {
        var usuario = await _context.Usuarios.FindAsync(idUsuario);
        if (usuario != null)
        {
            usuario.Clave = nuevaClave;
            _context.Usuarios.Update(usuario);
            await GuardarCambiosAsync();
        }
    }

    // Implementación del método de la interfaz genérica para obtener todos
    async Task<IReadOnlyList<Usuario>> IRepositorioGenerico<Usuario>.ObtenerTodosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    // Implementación opcional para especificaciones (a futuro puedes usar un Evaluador de Especificaciones)
    public Task<Usuario> ObtenerPorEspecificacionAsync(IEspecificacion<Usuario> spec)
    {
        throw new NotImplementedException("Este método aún no ha sido implementado.");
    }

    public Task<IReadOnlyList<Usuario>> ListarPorEspecificacionAsync(IEspecificacion<Usuario> spec)
    {
        throw new NotImplementedException("Este método aún no ha sido implementado.");
    }

    // Método privado para centralizar guardado
    private async Task GuardarCambiosAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task<IReadOnlyList<Usuario>> BuscarAsync(Expression<Func<Usuario, bool>> predicado)
    {
        throw new NotImplementedException();
    }

    public Task<int> ContarPorEspecificacionAsync(IEspecificacion<Usuario> spec)
    {
        throw new NotImplementedException();
    }
}
