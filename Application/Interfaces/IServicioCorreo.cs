using System.Threading.Tasks;

namespace Manantial.Application.Interfaces
{
    public interface IServicioCorreo
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo);
    }
}
