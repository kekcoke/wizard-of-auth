namespace wizard_of_auth.Application.Token;

/// <summary>
/// Parameters for token validation
/// </summary>
public class TokenValidationParameters
{
    public bool ValidateIssuer { get; init; } = true;
    public string? ValidIssuer { get; init; }
    public bool ValidateAudience { get; init; } = true;
    public IReadOnlyList<string>? ValidAudiences { get; init; }
    public bool ValidateLifetime { get; init; } = true;
    public TimeSpan ClockSkew { get; init; } = TimeSpan.FromMinutes(5);
    public bool ValidateSignature { get; init; } = true;
    public bool RequireExpirationTime { get; init; } = true;
    public bool RequireSignedTokens { get; init; } = true;
}