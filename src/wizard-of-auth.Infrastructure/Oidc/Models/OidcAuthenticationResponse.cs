namespace wizard_of_auth.Infrastructure.Oidc.Models;

public class OidcAuthenticationResponse
{
    public string? Code { get; init; }
    public string? AccessToken { get; init; }
    public string? IdToken { get; init; }
    public string? TokenType { get; init; }
    public int? ExpiresIn { get; init; }
    public string? State { get; init; }
    public string? SessionState { get; init; }
}