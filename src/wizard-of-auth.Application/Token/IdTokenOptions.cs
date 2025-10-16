using System.Security.Claims;

namespace wizard_of_auth.Application.Token;

/// <summary>
/// Options for ID token generation (OpenID Connect)
/// </summary>
public class IdTokenOptions
{
    public TimeSpan? Lifetime { get; init; }
    public string? AuthTime { get; init; }
    public IReadOnlyList<string>? Amr { get; init; }
    public string? Acr { get; init; }
    public IReadOnlyList<Claim>? AdditionalClaims { get; init; }
    public bool IncludeUserInfoClaims { get; init; } = true;
}
