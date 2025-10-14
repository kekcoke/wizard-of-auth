namespace wizard_of_auth.Core.Entities.Authentication;

/// <summary>
/// Authentication attempt result
/// </summary>
public class AuthenticationResult
{
    public bool IsSuccess { get; init; }
    public Guid? UserId { get; init; }
    public bool RequiresMfa { get; init; }
    public string? MfaSessionToken { get; init; }
    public IReadOnlyList<string>? AvailableMfaMethods { get; init; }
    public AuthenticationFailureReason? FailureReason { get; init; }
    public string? ErrorMessage { get; init; }
    public int? RemainingAttempts { get; init; }
    public DateTime? AccountLockedUntil { get; init; }
}