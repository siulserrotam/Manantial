/*
create table BARRIO(
IdBarrio varchar(6) NOT NULL,
Descripcion varchar (45) NOT NULL,
Fk_IdDepartamento varchar (2) NOT NULL,
Fk_IdCiudad varchar (4) NOT NULL
)

*/
namespace Core.Entities
{
    public class Barrio
    {
        public string IdBarrio { get; set; }  // Esto será la clave primaria según la convención de EF Core.
        public string Descripcion { get; set; }
        public string Fk_IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }
        public string Fk_IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
