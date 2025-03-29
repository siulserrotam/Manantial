using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class EspecificacionProductosConCategoriaYMarca : EspecificacionBase<Producto>
    {
        public EspecificacionProductosConCategoriaYMarca()
             : base(x => true) // Aquí puedes poner tus filtros (por ejemplo, un producto activo)
        {
            AgregarIncluir(p => p.Categoria);
            AgregarIncluir(p => p.Marca);
        }
        
        public EspecificacionProductosConCategoriaYMarca(int id)
             : base(x => x.Id == id) // Filtro por Id
        {
            AgregarIncluir(p => p.Categoria);
            AgregarIncluir(p => p.Marca);
        }
    }
}