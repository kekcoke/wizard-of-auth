namespace wizard_of_auth.Core.Entities.Authentication;

/// <summary>
/// Result of authorization code exchange
/// </summary>
public class AuthorizationCodeExchangeResult
{
    public string AccessToken { get; init; } = string.Empty;
    public string? RefreshToken { get; init; }
    public string? IdToken { get; init; }
    public string TokenType { get; init; } = "Bearer";
    public int ExpiresIn { get; init; }
    public IReadOnlyList<string> Scopes { get; init; } = Array.Empty<string>();
}