namespace Manantial.Application.DTOs
{
    public class DtoVenta
    {
        public int IdVenta { get; set; }
        public int Fk_IdCliente { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string Contacto { get; set; }
        public string FK_IdBarrio { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string IdTransaccion { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
