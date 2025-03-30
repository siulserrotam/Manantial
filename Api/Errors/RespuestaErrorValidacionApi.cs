namespace API.Errors
{
    public class RespuestaErrorValidacionApi : RespuestaApi
    {
        public RespuestaErrorValidacionApi() : base(400)
        {
        }

        public IEnumerable<string> Errores { get; set; }
    }
}
