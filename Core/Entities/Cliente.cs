/*
create table CLIENTE(
IdCliente int primary key identity,
Nombres varchar(100),
Apellidos varchar(100),
Correo varchar(100),
Clave varchar(150),
Restablecer bit default 0,
FechaRegistro datetime default getdate()
*/

namespace Core.Entities
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
