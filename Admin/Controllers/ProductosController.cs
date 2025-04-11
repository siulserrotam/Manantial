using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;

namespace Admin.Controllers;

public class ProductosController : Controller
{
    private readonly ILogger<ProductosController> _logger;

    public ProductosController(ILogger<ProductosController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

}
