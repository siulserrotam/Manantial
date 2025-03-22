
namespace Manantial.Core.Entities
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