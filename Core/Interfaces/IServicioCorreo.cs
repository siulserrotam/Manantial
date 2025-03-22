using System.Threading.Tasks;

namespace Manantial.Core.Interfaces
{
    public interface IServicioCorreo
    {
        Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo);
    }
}
