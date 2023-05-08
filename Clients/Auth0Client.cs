using System.Text.Json;
using AuthService.Clients.Models;

namespace AuthService.Clients;

public class Auth0Client
{
    private readonly string domain;
    private readonly string audience;
    private readonly string clientId;
    private readonly string clientSecret;

    public Auth0Client(string domain, string audience, string clientId, string clientSecret)
    {
        this.domain = domain;
        this.audience = audience;
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }

    public async Task<TokenResponse> CreateAccessToken()
    {
        using var client = new HttpClient();
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("audience", audience),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });
        var response = await client.PostAsync(domain + "oauth/token", content);
        var responseContent = await response.Content.ReadAsStreamAsync();
        return JsonSerializer.Deserialize<TokenResponse>(responseContent);
    }
}