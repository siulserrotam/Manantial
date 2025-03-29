namespace Application.DTOs
{
    public class DtoDetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int Fk_IdVenta { get; set; }
        public int Fk_IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
