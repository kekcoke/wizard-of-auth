namespace wizard_of_auth.Core.Entities;

public enum SessionTerminationReason
{
    UserInitiated,
    Timeout,
    AdminForced,
    SecurityBreach,
    TokenRevoked,
    PasswordChanged
}
