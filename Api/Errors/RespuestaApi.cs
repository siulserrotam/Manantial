namespace API.Errors
{
    public class RespuestaApi
    {
        public int CodigoEstado { get; set; }  // Código HTTP
        public string Mensaje { get; set; }  // Mensaje de error
        public string[] Errores { get; set; }  // Lista de errores opcional

        public RespuestaApi(int codigoEstado, string mensaje = null, string[] errores = null)
        {
            CodigoEstado = codigoEstado;
            Mensaje = mensaje ?? ObtenerMensajePredeterminadoParaCodigoEstado(codigoEstado);
            Errores = errores ?? new string[] { };  // Inicializar para evitar valores nulos
        }

        private static string ObtenerMensajePredeterminadoParaCodigoEstado(int codigoEstado)
        {
            return codigoEstado switch
            {
                400 => "Solicitud incorrecta.",
                401 => "No autorizado.",
                403 => "Prohibido acceder a este recurso.",
                404 => "Recurso no encontrado.",
                422 => "Error de validación en los datos enviados.",
                500 => "Error interno del servidor. Inténtalo más tarde.",
                _ => "Ha ocurrido un error inesperado."  // Mensaje por defecto para otros códigos
            };
        }
    }
}
