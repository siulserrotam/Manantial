using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;

namespace Admin.Controllers;

public class MarcasController : Controller
{
    private readonly ILogger<MarcasController> _logger;

    public MarcasController(ILogger<MarcasController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

}
