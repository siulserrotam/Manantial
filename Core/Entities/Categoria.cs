/*
create table CATEGORIA(
IdCategoria int primary key identity,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
*/
namespace Core.Entities
{
    public class Categoria : EntidadBase
    {
        public string Descripcion { get; set; }
    }
}