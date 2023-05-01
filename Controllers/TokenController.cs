using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

[ApiController]
[Route("tokens")]
public class TokenController : ControllerBase
{
    private readonly Auth0Client client;

    public TokenController(Auth0Client client)
    {
        this.client = client;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateToken()
    {
        return Ok(await client.CreateAccessToken());
    }
}