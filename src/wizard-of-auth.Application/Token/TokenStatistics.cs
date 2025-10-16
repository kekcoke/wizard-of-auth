namespace wizard_of_auth.Application.Token;

/// <summary>
/// Token usage statistics
/// </summary>
public class TokenStatistics
{
    public int TotalActiveTokens { get; init; }
    public int ActiveAccessTokens { get; init; }
    public int ActiveRefreshTokens { get; init; }
    public int TokensIssuedInPeriod { get; init; }
    public int TokensRevokedInPeriod { get; init; }
    public Dictionary<string, int> TokensByClient { get; init; } = new();
    public Dictionary<string, int> TokensByGrantType { get; init; } = new();
}