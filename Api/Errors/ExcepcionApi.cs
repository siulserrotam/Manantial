using API.Errors;

namespace API.Errors
{
    public class ExcepcionApi : RespuestaApi
    {
        // Constructor que recibe los parámetros y pasa el código de estado y mensaje a la clase base
        public ExcepcionApi(int codigoEstado, string mensaje = null, string detalles = null)
            : base(codigoEstado, mensaje)
        {
            Detalles = detalles; // Asigna los detalles adicionales del error
        }

        // Propiedad para los detalles adicionales del error
        public string Detalles { get; set; }
    }
}
