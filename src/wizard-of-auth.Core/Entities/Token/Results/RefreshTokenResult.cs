namespace wizard_of_auth.Core.Entities;

/// <summary>
/// CREDENTIAL: Result of refresh token generation
/// </summary>
public class RefreshTokenResult
{
    public string RefreshToken { get; init; } = string.Empty;
    public string TokenId { get; init; } = string.Empty;
    public DateTime IssuedAt { get; init; }
    public DateTime? ExpiresAt { get; init; }
}
