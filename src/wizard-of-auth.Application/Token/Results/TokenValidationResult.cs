using System.Security.Claims;
using wizard_of_auth.Core.Enums.Actions.Token;

namespace wizard_of_auth.Application.Token.Results;

/// <summary>
/// Token validation result with claims
/// </summary>
public class TokenValidationResult
{
    public bool IsValid { get; init; }
    public ClaimsPrincipal? Principal { get; init; }
    public IReadOnlyList<Claim>? Claims { get; init; }
    public Guid? UserId { get; init; }
    public Guid? ClientId { get; init; }
    public IReadOnlyList<string>? Scopes { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public TokenValidationFailureReason? FailureReason { get; init; }
    public string? ErrorMessage { get; init; }
}