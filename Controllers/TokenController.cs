using AuthService.Clients;
using AuthService.Contracts;
using Microsoft.AspNetCore.Mvc;
using static Nelibur.ObjectMapper.TinyMapper;

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
    public async Task<Token> CreateToken()
    {
        var response = await client.CreateAccessToken();
        return Map<Token>(response);
    }
}