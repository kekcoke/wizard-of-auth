namespace wizard_of_auth.Application.Oidc;

public class OidcClientRegistrationRequest
{
    public IReadOnlyList<string> RedirectUris { get; init; } = Array.Empty<string>();
    public string? ClientName { get; init; }
    public string? ClientUri { get; init; }
    public string? LogoUri { get; init; }
    public IReadOnlyList<string>? Contacts { get; init; }
    public string? TosUri { get; init; }
    public string? PolicyUri { get; init; }
    public string? JwksUri { get; init; }
    public string? SoftwareId { get; init; }
    public string? SoftwareVersion { get; init; }
}