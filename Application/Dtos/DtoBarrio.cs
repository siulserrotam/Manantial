namespace Application.DTOs
{
    public class DtoBarrio
    {
        public string IdBarrio { get; set; }
        public string Descripcion { get; set; }
        public string Fk_IdDepartamento { get; set; }
        public string Fk_IdCiudad { get; set; }
    }
}
