/*
create table CIUDAD(
IdCiudad varchar(4) NOT NULL,
Descripcion varchar (45) NOT NULL,
Fk_IdDepartamento varchar (2) NOT NULL
)

*/
namespace Core.Entities
{
    public class Ciudad
    {
        public string IdCiudad { get; set; }  // Clave primaria
        public string Descripcion { get; set; }  // Descripción de la ciudad
        public string Fk_IdDepartamento { get; set; }  // Clave foránea que puede ser nula

        public Departamento Departamento { get; set; }  // Relación con Departamento
    }
}
