using Manantial.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Manantial.Infraestructure.Rrepositories
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly DbContext _contexto;
        private readonly DbSet<T> _dbSet;

        public RepositorioGenerico(DbContext contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
            _dbSet = _contexto.Set<T>();
        }

        public async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync(); // Operación asíncrona
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); // Operación asíncrona
        }

        public async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado)
        {
            return await _dbSet.Where(predicado).AsNoTracking().ToListAsync(); // Operación asíncrona
        }

        public async Task AgregarAsync(T entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            await _dbSet.AddAsync(entidad); // Operación asíncrona
        }

        public async Task ActualizarAsync(T entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            _dbSet.Attach(entidad);
            _contexto.Entry(entidad).State = EntityState.Modified; // Modificación del estado
            await Task.CompletedTask; // No hay una operación asíncrona específica para actualizar, pero puedes hacer la actualización en segundo plano.
        }

        public async Task EliminarAsync(int id)
        {
            var entidad = await _dbSet.FindAsync(id); // Operación asíncrona
            if (entidad == null)
                throw new ArgumentNullException(nameof(entidad));

            _dbSet.Remove(entidad); // Eliminar entidad
            await Task.CompletedTask; // No hay una operación asíncrona específica para eliminar, pero puedes hacer la eliminación en segundo plano.
        }

        public async Task GuardarCambiosAsync()
        {
            await _contexto.SaveChangesAsync(); // Guardar cambios de manera asíncrona
        }
    }
}
