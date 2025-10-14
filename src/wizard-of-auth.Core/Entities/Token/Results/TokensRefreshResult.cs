namespace wizard_of_auth.Core.Entities;

/// <summary>
/// ACTION: Result of tokens refresh operation. Contains both access token and optionally refresh token.
/// </summary>
public class TokensRefreshResult
{
    public string AccessToken { get; init; } = string.Empty;
    public string? RefreshToken { get; init; }
    public string TokenType { get; init; } = "Bearer";
    public int ExpiresIn { get; init; }
    public IReadOnlyList<string> Scopes { get; init; } = Array.Empty<string>();
}