using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Manantial.Core.Interfaces;

namespace Manantial.Core.Specifications
{
    public class EspecificacionBase<T> : IEspecificacion<T>
    {
        public EspecificacionBase(Expression<Func<T, bool>> criterio = null)
        {
            Criterio = criterio;
            Incluir = new List<Expression<Func<T, object>>>();
        }

        public Expression<Func<T, bool>> Criterio { get; }
        public List<Expression<Func<T, object>>> Incluir { get; }
        public Expression<Func<T, object>> OrdenarPor { get; private set; }
        public Expression<Func<T, object>> OrdenarPorDescendente { get; private set; }
        public int Tomar { get; private set; }
        public int Omitir { get; private set; }
        public bool EsPaginacionHabilitada => Tomar > 0;

        public object Includes => throw new NotImplementedException();

        public EspecificacionBase<T> AgregarIncluir(Expression<Func<T, object>> expresionIncluir)
        {
            Incluir.Add(expresionIncluir);
            return this;
        }

        public EspecificacionBase<T> AplicarOrdenarPor(Expression<Func<T, object>> expresionOrdenarPor)
        {
            OrdenarPor = expresionOrdenarPor;
            return this;
        }

        public EspecificacionBase<T> AplicarOrdenarPorDescendente(Expression<Func<T, object>> expresionOrdenarPorDescendente)
        {
            OrdenarPorDescendente = expresionOrdenarPorDescendente;
            return this;
        }

        public EspecificacionBase<T> AplicarPaginacion(int omitir, int tomar)
        {
            Omitir = omitir;
            Tomar = tomar;
            return this;
        }
    }
}
