using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infraestructure.Data;
using Core.Interfaces;

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
            // Verifica si el ID es válido
            return await _contexto.Set<T>().FindAsync(id); 
        }
         public Task ObtenerProductosAsync()
        {
            // Implementación de la lógica para obtener productos
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ObtenerTodosAsync()
        {
            // Obtiene todas las entidades de tipo T de forma asincrónica
            return await _contexto.Set<T>().ToListAsync();
        }

         private IQueryable<T> AplicarEspecificacion(IEspecificacion<T> spec)
        {
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
        
       
    }
}
   

     
     
      

       