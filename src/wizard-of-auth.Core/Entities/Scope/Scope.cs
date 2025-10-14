namespace wizard_of_auth.Core.Entities.Scope;

public class Scope
{
    public string Name { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string? Description { get; init; }
    public bool IsDefault { get; init; }
    public bool RequiresConsent { get; init; } = true;
    public bool ShowInDiscovery { get; init; } = true;
    public IReadOnlyList<string> Claims { get; init; } = Array.Empty<string>();
}