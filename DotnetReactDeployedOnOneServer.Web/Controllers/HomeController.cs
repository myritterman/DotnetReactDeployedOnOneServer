using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using DotnetReactDeployedOnOneServer.Web.Models;

namespace DotnetReactDeployedOnOneServer.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot", "index.html"), MediaTypeNames.Text.Html);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
