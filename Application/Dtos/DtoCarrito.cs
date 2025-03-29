namespace Application.DTOs
{
    public class DtoCarrito
    {
        public int IdCarrito { get; set; }
        public int Fk_IdCliente { get; set; }
        public int Fk_IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
