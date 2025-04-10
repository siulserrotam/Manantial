using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Necesario para HttpContext.Session
using System.Diagnostics;  // Para depuración
using System.Threading.Tasks;
using BCrypt.Net; // Librería para manejar hashing de contraseñas (requiere instalar BCrypt.Net-Next)

public class CuentasController : Controller
{
    private readonly UsuarioService _usuarioService;

    public CuentasController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public IActionResult IniciarSesion()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IniciarSesion(string correo, string clave)
    {
        Debug.WriteLine($"Correo recibido en login: {correo}");

        var usuario = await _usuarioService.ObtenerUsuarioPorCorreo(correo);

        if (usuario == null)
        {
            Debug.WriteLine("Usuario no encontrado en la API.");
            ViewBag.Error = "Usuario no encontrado o cuenta inactiva.";
            return View();
        }

        Debug.WriteLine($"Usuario encontrado: {usuario.Nombres}, Estado: {(usuario.Activo ? "Activo" : "Inactivo")}");

        if (!usuario.Activo)
        {
            Debug.WriteLine("⚠ Cuenta inactiva.");
            ViewBag.Error = "Cuenta inactiva. Contacte al administrador.";
            return View();
        }

        // Validar la contraseña con hashing
        if (string.IsNullOrEmpty(usuario.Clave) || !BCrypt.Net.BCrypt.Verify(clave, usuario.Clave))
        {
            Debug.WriteLine("Contraseña incorrecta.");
            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }

        Debug.WriteLine("Autenticación exitosa. Estableciendo sesión.");
        HttpContext.Session.SetString("Usuario", usuario.Nombres);

        return RedirectToAction("Panel", "Inicio");
    }

    public IActionResult RecuperarClave()
    {
        return View();
    }

    public IActionResult CerrarSesion()
    {
        Debug.WriteLine("Cerrando sesión.");
        HttpContext.Session.Clear(); // Limpiar la sesión
        return RedirectToAction("IniciarSesion");
    }
}