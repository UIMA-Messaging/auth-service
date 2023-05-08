using Microsoft.AspNetCore.Authorization;

namespace AuthService.Authentication;

public class ScopeRequirements : IAuthorizationRequirement
{
    public string Issuer { get; }
    public string Scope { get; }

    public ScopeRequirements(string scope, string issuer)
    {
        Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }
}