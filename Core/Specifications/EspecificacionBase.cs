using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications
{
    public class EspecificacionBase<T> : IEspecificacion<T>
    {
        public EspecificacionBase(Expression<Func<T, bool>> criterio)
        {
            Criterio = criterio;
            Incluir = new List<Expression<Func<T, object>>>();
        }
        // Criterios de filtrado
        public Expression<Func<T, bool>> Criterio { get; } 
        
        // Incluye para carga impaciente
        public List<Expression<Func<T, object>>> Incluir { get; } = new List<Expression<Func<T, object>>>();

        // Ordenar por
        public Expression<Func<T, object>> OrdenarPor { get; private set; }

        // Ordenar por descendente
        public Expression<Func<T, object>> OrdenarPorDescendente { get; private set; }

        // Paginacion
        public int Tomar { get; private set; }
        public int Omitir { get; private set; }
        
        // Método para agregar un Include (entidad relacionada) a la lista de inclusiones
        protected void AgregarIncluir(Expression<Func<T, object>> expresionIncluir)
        {
            Incluir.Add(expresionIncluir);
        }

        // Método para configurar el ordenamiento ascendente
        public void AplicarOrdenarPor(Expression<Func<T, object>> expresionOrdenarPor)
        {
            OrdenarPor = expresionOrdenarPor;
        }

        // Método para configurar el ordenamiento descendente
        public void AplicarOrdenarPorDescendente(Expression<Func<T, object>> expresionOrdenarPorDescendente)
        {
            OrdenarPorDescendente = expresionOrdenarPorDescendente;
        }

        // Método para agregar la paginación a la especificación
        public void AplicarPaginacion(int omitir, int tomar)
        {
            Omitir = omitir;
            Tomar = tomar;
        }

    }
}
