using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IServicioCorreo
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo);
    }
}
