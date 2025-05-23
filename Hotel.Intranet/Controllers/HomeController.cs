using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hotel.Intranet.Models;

namespace Hotel.Intranet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Rooms()
    {
        return View();
    }

    public IActionResult Atractions()
    {
        return View();
    }

    public IActionResult Prices()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
