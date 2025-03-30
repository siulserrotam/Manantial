/*
create table MARCA(
IdMarca int primary key identity,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
*/
namespace Core.Entities
{
    public class Marca : EntidadBase
    {
        public string Descripcion { get; set; }
    }
}