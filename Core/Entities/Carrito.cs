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