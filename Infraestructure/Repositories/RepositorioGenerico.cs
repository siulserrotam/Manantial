using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructure.Data;
using Core.Interfaces;
using System.Linq.Expressions;

namespace Infraestructure.Repositories
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : EntidadBase
    {
        private readonly ContextoTienda _contexto;

        public RepositorioGenerico(ContextoTienda contexto)
        {
            _contexto = contexto;
        }

        public async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _contexto.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            return await _contexto.Set<T>().ToListAsync();
        }

        private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> spec)
        {
            // Aplica la lógica definida en la especificación al conjunto de datos
            return EvaluadorDeEspecificaciones<T>.ObtenerConsulta(_contexto.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> ObtenerPorEspecificacionAsync(IEspecificacion<T> spec)
        {
            return await AplicarEspecificacion(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListarPorEspecificacionAsync(IEspecificacion<T> spec)
        {
            return await AplicarEspecificacion(spec).ToListAsync();
        }

        public Task AgregarAsync(T entidad)
        {
            throw new NotImplementedException();
        }

        public Task ActualizarAsync(T entidad)
        {
            throw new NotImplementedException();
        }

        public Task EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> BuscarAsync(Expression<Func<T, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public Task<int> ContarPorEspecificacionAsync(IEspecificacion<T> spec)
        {
            throw new NotImplementedException();
        }
    }
}
