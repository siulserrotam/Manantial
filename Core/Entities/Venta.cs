/*
create table VENTA(
IdVenta int primary key identity,
FK_idCliente int references CLIENTE(idCliente),
TotalProducto int,
MontoTotal decimal(10,2),
Contacto varchar(50),
FK_IdBarrio varchar(10), 
Telefono varchar(50),
Direccion varchar(500),
IdTransaccion varchar(50),
FechaVenta datetime default getdate()
)
*/
namespace Core.Entities
{
    public class Venta : EntidadBase
    {
        public int Fk_IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string Contacto { get; set; }
        public string Fk_IdBarrio { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string IdTransaccion { get; set; }
        public DateTime FechaVenta { get; internal set; }
    }
 
}