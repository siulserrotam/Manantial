namespace Manantial.Application.DTOs
{
    public class DtoRetornarCliente
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Restablecer { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
