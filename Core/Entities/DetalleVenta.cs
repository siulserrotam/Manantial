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