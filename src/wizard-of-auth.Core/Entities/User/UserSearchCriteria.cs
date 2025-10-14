namespace wizard_of_auth.Core.Entities;

/// <summary>
/// Search criteria for users
/// </summary>
public class UserSearchCriteria
{
    public string? EmailContains { get; init; }
    public string? NameContains { get; init; }
    public Guid? TenantId { get; init; }
    public bool? IsActive { get; init; }
    public bool? IsLocked { get; init; }
    public bool? EmailVerified { get; init; }
    public DateTime? CreatedAfter { get; init; }
    public DateTime? CreatedBefore { get; init; }
    public DateTime? LastLoginAfter { get; init; }
    public DateTime? LastLoginBefore { get; init; }
    public IReadOnlyList<string>? Roles { get; init; }
}