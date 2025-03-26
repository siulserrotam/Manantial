namespace Manantial.Core.Entities
{
    public class Ciudad
    {
        public string IdCiudad { get; set; }  // Clave primaria
        public string Descripcion { get; set; }  // Descripción de la ciudad
        public string? Fk_IdDepartamento { get; set; }  // Clave foránea que puede ser nula

        public Departamento Departamento { get; set; }  // Relación con Departamento
    }
}
