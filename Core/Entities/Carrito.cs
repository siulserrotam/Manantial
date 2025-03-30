/*
create table CARRITO(
IdCarrito int primary key identity,
Fk_IdCliente int references CLIENTE(IdCliente),
Fk_IdCategoria int references PRODUCTO(IdProducto),
Cantidad int
)
*/

namespace Core.Entities
{
        public class Carrito
    {
        public int IdCarrito { get; set; }
        public int Fk_IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int Fk_IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }

}