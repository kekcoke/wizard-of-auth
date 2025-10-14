namespace wizard_of_auth.Core.Enums.Actions.Token;

public enum TokenValidationFailureReason
{
    UserRequest,
    AdminAction,
    SecurityBreach,
    TokenExpired,
    Logout,
    PasswordChange
}
