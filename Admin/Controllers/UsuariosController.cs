using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;

namespace Admin.Controllers;

public class UsuariosController : Controller
{
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(ILogger<UsuariosController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

}
