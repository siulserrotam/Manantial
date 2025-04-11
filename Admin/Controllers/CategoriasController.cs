using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;

namespace Admin.Controllers;

public class CategoriasController : Controller
{
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(ILogger<CategoriasController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

}
