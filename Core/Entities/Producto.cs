/*
create table PRODUCTO(
IdProducto int primary key identity,
Nombre varchar(500),
Descripcion varchar(500),
Fk_IdMarca int references MARCA(IdMarca),
Fk_IdCategoria int references CATEGORIA(IdCategoria),
Precio decimal(10,2) default 0,
stock int,
RutaImagen varchar(100),
NombreImagen varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
*/
namespace Core.Entities 
{
    public class Producto : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Fk_IdMarca { get; set; }
        public Marca Marca { get; set; }
        public int Fk_IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; } = 0;
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }

        public bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
