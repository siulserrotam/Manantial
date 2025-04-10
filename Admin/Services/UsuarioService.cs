using Application.DTOs;
using System.Diagnostics;  // Para Debug.WriteLine()
using System.Net.Http.Json;
using System.Text.Json;

public class UsuarioService
{
    private readonly HttpClient _httpClient;

    public UsuarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DtoUsuario?> ObtenerUsuarioPorCorreo(string correo)
    {
        try
        {
            Debug.WriteLine($"🔍 Buscando usuario con correo: {correo}");

            var response = await _httpClient.GetAsync($"api/Usuarios?correo={correo}");
            response.EnsureSuccessStatusCode(); // Lanza excepción si el código no es 2xx

            var usuarios = await response.Content.ReadFromJsonAsync<List<DtoUsuario>>(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (usuarios == null || usuarios.Count == 0)
            {
                Debug.WriteLine($"⚠ No se encontraron usuarios en la respuesta.");
                return null;
            }

            var usuario = usuarios.FirstOrDefault(u => u.Correo?.Equals(correo, StringComparison.OrdinalIgnoreCase) == true);

            if (usuario == null)
                Debug.WriteLine($"⚠ Usuario con correo {correo} no encontrado en la lista.");

            return usuario;
        }
        catch (JsonException ex)
        {
            Debug.WriteLine($"❌ Error al deserializar JSON: {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine($"❌ Error en la solicitud HTTP: {ex.Message}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"❌ Error desconocido: {ex.Message}");
        }

        return null;
    }
}
