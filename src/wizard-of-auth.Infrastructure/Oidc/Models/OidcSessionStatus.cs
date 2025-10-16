namespace wizard_of_auth.Infrastructure.Oidc.Models;

public class OidcSessionStatus
{
    public bool IsActive { get; init; }
    public string? SessionId { get; init; }
    public DateTime? LastActivity { get; init; }
    public DateTime? ExpiresAt { get; init; }
}