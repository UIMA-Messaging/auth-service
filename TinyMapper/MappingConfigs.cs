using AuthService.Clients.Models;
using AuthService.Contracts;

namespace AuthService.TinyMapper;

public class MappingConfigs
{
    public static void Configure()
    {
        Nelibur.ObjectMapper.TinyMapper.Bind<TokenResponse, Token>();
    }
}