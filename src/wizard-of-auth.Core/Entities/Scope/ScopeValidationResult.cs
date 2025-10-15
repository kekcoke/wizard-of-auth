namespace wizard_of_auth.Core.Entities.Scope;

public class ScopeValidationResult
{
    public bool IsValid { get; init; }
    public IReadOnlyList<string> ValidScopes { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> InvalidScopes { get; init; } = Array.Empty<string>();
    public string? ErrorMessage { get; init; }
}