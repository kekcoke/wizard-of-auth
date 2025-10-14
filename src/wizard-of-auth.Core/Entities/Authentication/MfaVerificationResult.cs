using wizard_of_auth.Core.Enums.Actions;

namespace wizard_of_auth.Core.Entities.Authentication;

/// <summary>
/// MFA verification result
/// </summary>
public class MfaVerificationResult
{
    public bool IsSuccess { get; init; }
    public Guid? UserId { get; init; }
    public MfaFailureReason? FailureReason { get; init; }
    public string? ErrorMessage { get; init; }
    public int? RemainingAttempts { get; init; }
    public DateTime? LockedUntil { get; init; }
}