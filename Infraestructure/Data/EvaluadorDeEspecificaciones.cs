using Core.Entities;  // Importamos la clase EntidadBase desde el espacio de nombres Core.Entities.
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Core.Interfaces;

namespace Infraestructure.Data  // Espacio de nombres adecuado para la infraestructura de tu proyecto.
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
            if (especificacion.Incluir != null && ((IEnumerable<Expression<Func<TEntity, object>>>)especificacion.Incluir).Any())
            {
                // Aplicamos los "Includes" de la especificación, lo que permite incluir relaciones.
                consulta = ((IEnumerable<Expression<Func<TEntity, object>>>)especificacion.Incluir)
                    .Aggregate(consulta, 
                        (consultaActual, incluir) => consultaActual.Include(incluir)) ?? consulta;
            }

            // Retornamos la consulta ya con los filtros y relaciones aplicadas.
            return consulta;
        }
    }
}
