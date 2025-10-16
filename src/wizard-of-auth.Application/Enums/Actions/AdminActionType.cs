namespace wizard_of_auth.Core.Enums.Actions;

public enum AdminActionType
{
    UserCreated,
    UserDeleted,
    UserDisabled,
    UserEnabled,
    PasswordReset,
    MfaReset,
    RoleAssigned,
    RoleRevoked,
    TenantCreated,
    ClientRegistered,
    PolicyUpdated
}