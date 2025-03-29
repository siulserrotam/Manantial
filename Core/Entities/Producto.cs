
namespace Core.Entities 
{
    public class Producto : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Fk_IdMarca { get; set; }
        public Marca Marca { get; set; }
        public int Fk_IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; } = 0;
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }

        public bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
