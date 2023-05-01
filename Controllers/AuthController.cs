using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("auth")]
public class WeatherForecastController : ControllerBase
{
    [HttpPost("verify")]
    public IActionResult Verify()
    {
        return Ok();
    }
}

