namespace wizard_of_auth.Application.Consent.Models;

public class ConsentCheckResult
{
    public bool ConsentRequired { get; init; }
    public Guid? ExistingConsentId { get; init; }
    public IReadOnlyList<string> ConsentedScopes { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> NewScopes { get; init; } = Array.Empty<string>();
}
