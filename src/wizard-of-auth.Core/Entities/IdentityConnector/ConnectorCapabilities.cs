using wizard_of_auth.Core.Enums;

namespace wizard_of_auth.Core.Entities.IdentityConnector;

public class ConnectorCapabilities
{
    public bool SupportsPasswordAuthentication { get; init; }
    public bool SupportsTokenAuthentication { get; init; }
    public bool SupportsUserRegistration { get; init; }
    public bool SupportsPasswordChange { get; init; }
    public bool SupportsPasswordReset { get; init; }
    public bool SupportsMfa { get; init; }
    public IReadOnlyList<MfaMethod> SupportedMfaMethods { get; init; } = Array.Empty<MfaMethod>();
    public bool SupportsUserSync { get; init; }
    public bool SupportsGroups { get; init; }
    public bool SupportsRoles { get; init; }
}