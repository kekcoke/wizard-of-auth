using System.Security.Claims;

namespace wizard_of_auth.Application.Token;

/// <summary>
/// Options for token generation
/// </summary>
public class TokenOptions
{
    public TimeSpan? Lifetime { get; init; }
    public IReadOnlyList<Claim>? AdditionalClaims { get; init; }
    public IReadOnlyList<string>? Audiences { get; init; }
    public string? Issuer { get; init; }
    public string? Subject { get; init; }
    public bool IncludeUserClaims { get; init; } = true;
    public string? IpAddress { get; init; }
    public string? DeviceId { get; init; }
}