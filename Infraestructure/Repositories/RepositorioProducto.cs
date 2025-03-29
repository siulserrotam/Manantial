using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    public class RepositorioProducto : RepositorioGenerico<Producto>, IRepositorioProducto
    {
        private readonly ContextoTienda _contexto;

        public RepositorioProducto(ContextoTienda contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _contexto.Set<Producto>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Producto>> ObtenerProductosAsync()
        {
            return await _contexto.Set<Producto>()
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .ToListAsync();
        }

        public async Task<Producto> ObtenerProductoConEspecificacionAsync(IEspecificacion<Producto> spec)
        {
            return await AplicarEspecificacion(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Categoria>> ObtenerProductosPorCategoriaAsync()
        {
            return await _contexto.Set<Categoria>().ToListAsync();
        }

        public async Task<IReadOnlyList<Marca>> ObtenerProductosPorMarcaAsync()
        {
            return await _contexto.Set<Marca>().ToListAsync();
        }

        public async Task<IReadOnlyList<Producto>> ListarProductosAsync(EspecificacionProductosConCategoriaYMarca spec)
        {
            return await AplicarEspecificacion(spec).ToListAsync();
        }

        private IQueryable<Producto> AplicarEspecificacion(IEspecificacion<Producto> spec)
        {
            return EvaluadorDeEspecificaciones<Producto>.ObtenerConsulta(_contexto.Set<Producto>().AsQueryable(), spec);
        }
    }
}
