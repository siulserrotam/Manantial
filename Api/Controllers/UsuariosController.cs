using Application.DTOs;
using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ServicioUsuario _servicioUsuario;

        public UsuariosController(ServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }

        // ✅ GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoUsuario>>> ObtenerUsuarios()
        {
            var usuarios = await _servicioUsuario.ObtenerUsuarios();

            var usuariosDto = usuarios.Select(u => new DtoUsuario
            {
                IdUsuario = u.Id,
                Nombres = u.Nombres,
                Apellidos = u.Apellidos,
                Correo = u.Correo,
                Clave = u.Clave,
                Restablecer = u.Restablecer,
                Activo = u.Activo,
                FechaRegistro = u.FechaRegistro
            }).ToList();

            return Ok(usuariosDto);
        }

        // ✅ GET: api/usuario/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DtoUsuario>> ObtenerUsuarioPorId(int id)
        {
            var usuario = await _servicioUsuario.ObtenerUsuarioPorId(id);
            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado." });

            var dto = new DtoUsuario
            {
                IdUsuario = usuario.Id,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                Correo = usuario.Correo,
                Clave = usuario.Clave,
                Restablecer = usuario.Restablecer,
                Activo = usuario.Activo,
                FechaRegistro = usuario.FechaRegistro
            };

            return Ok(dto);
        }

        // ✅ POST: api/usuario
        [HttpPost]
        public async Task<ActionResult> CrearUsuario([FromBody] DtoUsuario dto)
        {
            if (dto == null)
                return BadRequest(new { mensaje = "Datos inválidos." });

            var usuario = new Usuario
            {
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Correo = dto.Correo,
                Clave = dto.Clave,
                Restablecer = dto.Restablecer,
                Activo = dto.Activo,
                FechaRegistro = dto.FechaRegistro
            };

            var creado = await _servicioUsuario.CrearUsuario(usuario);
            if (!creado)
                return BadRequest(new { mensaje = "No se pudo crear el usuario." });

            return Ok(new { mensaje = "Usuario creado exitosamente." });
        }

        // ✅ PUT: api/usuario/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] DtoUsuario dto)
        {
            if (dto == null || id != dto.IdUsuario)
                return BadRequest(new { mensaje = "Datos inválidos." });

            var usuario = new Usuario
            {
                Id = dto.IdUsuario,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Correo = dto.Correo,
                Clave = dto.Clave,
                Restablecer = dto.Restablecer,
                Activo = dto.Activo,
                FechaRegistro = dto.FechaRegistro
            };

            var actualizado = await _servicioUsuario.ActualizarUsuario(usuario);
            if (!actualizado)
                return NotFound(new { mensaje = "Usuario no encontrado." });

            return Ok(new { mensaje = "Usuario actualizado correctamente." });
        }

        // ✅ DELETE: api/usuario/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var eliminado = await _servicioUsuario.EliminarUsuario(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Usuario no encontrado o no se pudo eliminar." });

            return Ok(new { mensaje = "Usuario eliminado correctamente." });
        }
    }
}
