using Manantial.Core.Entities;  // Importamos la clase EntidadBase desde el espacio de nombres Core.Entities.
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Manantial.Core.Interfaces;

namespace Manantial.Infraestructure.Data  // Espacio de nombres adecuado para la infraestructura de tu proyecto.
{
    // Clase genérica que evalúa y aplica las especificaciones a las consultas.
    public class EvaluadorDeEspecificaciones<TEntity> where TEntity : EntidadBase  // Usamos EntidadBase como la clase base.
    {
        // Método estático para obtener una consulta filtrada de acuerdo con la especificación.
        public static IQueryable<TEntity> ObtenerConsulta(IQueryable<TEntity> consultaEntrada, 
        IEspecificacion<TEntity> especificacion)
        {
            var consulta = consultaEntrada;

            // Si hay un criterio de filtrado, lo aplicamos.
            if (especificacion.Criterio != null)
            {
                consulta = consulta.Where(especificacion.Criterio);
            }

            // Verificamos si hay Includes para aplicar
            if (especificacion.Includes != null && ((IEnumerable<Expression<Func<TEntity, object>>>)especificacion.Includes).Any())
            {
                // Aplicamos los "Includes" de la especificación, lo que permite incluir relaciones.
                consulta = ((IEnumerable<Expression<Func<TEntity, object>>>)especificacion.Includes)
                    .Aggregate(consulta, 
                        (consultaActual, incluir) => consultaActual.Include(incluir)) ?? consulta;
            }

            // Retornamos la consulta ya con los filtros y relaciones aplicadas.
            return consulta;
        }
    }
}
