namespace Application.DTOs
{
    public class DtoProducto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Fk_IdMarca { get; set; }
        public int Fk_IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
