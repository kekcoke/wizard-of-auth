namespace wizard_of_auth.Core.Enums.Actions;

public enum LogoutReason
{
    UserInitiated,
    SessionExpired,
    AdminForced,
    SecurityThreat,
    SingleLogout
}