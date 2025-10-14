namespace wizard_of_auth.Core.Enums.Actions;

public enum PasswordChangeReason
{
    UserInitiated,
    ForcedReset,
    Expired,
    AdminReset,
    SecurityBreach
}