namespace wizard_of_auth.Core.Entities.Consent;

public class UserConsent
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid ClientId { get; init; }
    public string ClientName { get; init; } = string.Empty;
    public IReadOnlyList<string> Scopes { get; init; } = Array.Empty<string>();
    public DateTime GrantedAt { get; init; }
    public DateTime? ExpiresAt { get; init; }
    public DateTime? LastUsed { get; init; }
}