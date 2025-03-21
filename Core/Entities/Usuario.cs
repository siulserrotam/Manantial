namespace Manantial.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Restablecer { get; set; } = true;
    }
 
}