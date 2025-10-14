namespace wizard_of_auth.Core.Enums.Actions;

public enum MfaFailureReason
{
    InvalidCode,
    CodeExpired,
    MaxAttemptsExceeded,
    MfaNotEnrolled,
    MethodNotSupported,
    RateLimitExceeded
}
