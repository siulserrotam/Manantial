namespace Manantial.Core.Entities
{
    public class Cliente : EntidadBase
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Restablecer { get; set; } = false;
    }
}
