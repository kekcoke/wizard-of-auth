namespace wizard_of_auth.Core.Entities.Authentication;

public enum AuthenticationFailureReason
{
    InvalidCredentials,
    AccountLocked,
    AccountDisabled,
    AccountNotFound,
    PasswordExpired,
    TenantMismatch,
    RateLimitExceeded,
    MfaRequired,
    ConnectionError
}