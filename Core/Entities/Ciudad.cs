namespace Manantial.Core.Entities
{
    public class Ciudad
    {
        public string IdCiudad { get; set; }
        public string Descripcion { get; set; }
        public string Fk_IdDepartamento { get; set; }
        public Departamento Departamento { get; set; }
    }
 
}