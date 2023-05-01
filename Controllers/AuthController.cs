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
        return Ok("This is a public message!");
    }
    
    [HttpPost("private")]
    [Authorize]
    public IActionResult Private()
    {
        return Ok("This is a private message!");
    }
    
    [HttpPost("private/scoped")]
    [Authorize("read:messages")]
    public IActionResult Scoped()
    {
        return Ok("This is a private scoped message!");
    }
}
