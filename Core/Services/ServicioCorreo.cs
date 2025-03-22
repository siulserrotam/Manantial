using System;
using System.Threading.Tasks;
using Manantial.Core.Interfaces;

namespace Manantial.Core.Services
{
    public class ServiceCorreo : IServicioCorreo
    {
        public async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo)
        {
            // En un escenario real, aquí iría la lógica para enviar un correo, usando SMTP, SendGrid, etc.
            // Aquí solo lo estamos simulando con un mensaje en la consola.

            await Task.Run(() =>
            {
                Console.WriteLine($"Enviando correo a: {destinatario}");
                Console.WriteLine($"Asunto: {asunto}");
                Console.WriteLine($"Cuerpo del mensaje: {cuerpo}");
                // Lógica real para enviar el correo aquí.
            });
        }
    }
}
