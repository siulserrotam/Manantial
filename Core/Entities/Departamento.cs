/*
create table DEPARTAMENTO(
IdDepartamento varchar(2) NOT NULL,
Descripcion varchar (45) NOT NULL
)
*/
namespace Core.Entities
{
    public class Departamento
    {
        public string IdDepartamento { get; set; }
        public string Descripcion { get; set; }
    }
 
}