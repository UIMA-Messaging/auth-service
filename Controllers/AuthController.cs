using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost("public")]
    public IActionResult Public()
    {
        return Ok();
    }
    
    [HttpPost("private")]
    [Authorize]
    public IActionResult Private()
    {
        return Ok();
    }
    
    [HttpPost("private/scoped")]
    [Authorize("group:create")]
    public IActionResult Scoped()
    {
        return Ok("This is a private scoped message!");
    }
}
