/* 
CREATE TABLE DETALLE_VENTA (
    IdDetalleVenta INT PRIMARY KEY IDENTITY,
    Fk_IdVenta INT REFERENCES VENTA(IdVenta),
    Fk_IdProducto INT REFERENCES PRODUCTO(IdProducto),
    Cantidad INT,
    Total DECIMAL(10,2)
)
*/

namespace Core.Entities
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int Fk_IdVenta { get; set; }
        public Venta Venta { get; set; }
        public int Fk_IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}