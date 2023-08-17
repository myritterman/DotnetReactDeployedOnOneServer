using Microsoft.AspNetCore.Mvc;

namespace DotnetReactDeployedOnOneServer.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok(new { Text = "Response from the server" });
    }
}
