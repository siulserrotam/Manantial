namespace Manantial.Core.Entities
{
        public class Barrio
    {
        public string IdBarrio { get; set; }
        public string Descripcion { get; set; }
        public string Fk_IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }
        public string Fk_IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}