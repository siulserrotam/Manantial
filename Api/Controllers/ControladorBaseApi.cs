using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manantial.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<T> : ControllerBase where T : class
    {
        private readonly DbContext _context;

        // Constructor para la inyección de dependencias del contexto de la base de datos
        public BaseApiController(DbContext context)
        {
            _context = context;
        }

        // Método para crear un nuevo registro
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] T entidad)
        {
            if (entidad == null)
            {
                return BadRequest("Entidad no proporcionada.");
            }

            _context.Set<T>().Add(entidad);  // Agregar la entidad al contexto
            await _context.SaveChangesAsync();  // Guardar los cambios en la base de datos

            // Devuelve la respuesta de éxito con el nuevo objeto creado
            return CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.GetType().GetProperty("Id")?.GetValue(entidad, null) }, entidad);
        }

        // Método para obtener todos los registros de una entidad
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var entidades = await _context.Set<T>().ToListAsync();  // Obtener todos los registros
            return Ok(entidades);  // Devolver todos los registros en formato JSON
        }

        // Método para obtener un registro por su Id
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var entidad = await _context.Set<T>().FindAsync(id);  // Buscar la entidad por su Id

            if (entidad == null)
            {
                return NotFound();  // Si no se encuentra la entidad, devuelve error 404
            }

            return Ok(entidad);  // Devolver la entidad encontrada
        }

        // Método para actualizar un registro
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] T entidad)
        {
            if (entidad == null || id <= 0)
            {
                return BadRequest("Datos inválidos.");
            }

            var entidadExistente = await _context.Set<T>().FindAsync(id);  // Buscar la entidad existente por su Id
            if (entidadExistente == null)
            {
                return NotFound();  // Si no se encuentra, devuelve error 404
            }

            // Actualizar los valores de la entidad existente con los nuevos valores
            _context.Entry(entidadExistente).CurrentValues.SetValues(entidad);
            await _context.SaveChangesAsync();  // Guardar los cambios en la base de datos

            return NoContent();  // Respuesta exitosa sin contenido
        }

        // Método para eliminar un registro
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var entidad = await _context.Set<T>().FindAsync(id);  // Buscar la entidad por su Id
            if (entidad == null)
            {
                return NotFound();  // Si no se encuentra la entidad, devuelve error 404
            }

            _context.Set<T>().Remove(entidad);  // Eliminar la entidad del contexto
            await _context.SaveChangesAsync();  // Guardar los cambios en la base de datos

            return NoContent();  // Respuesta exitosa sin contenido
        }
    }
}