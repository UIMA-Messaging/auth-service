using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public()
    {
        return Ok();
    }
    
    [HttpGet("private")]
    [Authorize]
    public IActionResult Private()
    {
        return Ok();
    }
    
    [HttpGet("private/scoped")]
    [Authorize("group:create")]
    public IActionResult Scoped()
    {
        return Ok();
    }
}
