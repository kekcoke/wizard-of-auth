using wizard_of_auth.Core.Enums;

namespace wizard_of_auth.Core.Entities;

/// <summary>
/// Information about active tokens
/// </summary>
public class ActiveTokenInfo
{
    public string TokenId { get; init; } = string.Empty;
    public TokenType TokenType { get; init; }
    public Guid ClientId { get; init; }
    public string ClientName { get; init; } = string.Empty;
    public DateTime IssuedAt { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public IReadOnlyList<string> Scopes { get; init; } = Array.Empty<string>();
    public string? DeviceId { get; init; }
    public string? IpAddress { get; init; }
    public DateTime? LastUsed { get; init; }
}