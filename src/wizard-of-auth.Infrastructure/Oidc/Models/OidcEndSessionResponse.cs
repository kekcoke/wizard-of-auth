namespace wizard_of_auth.Infrastructure.Oidc.Models;

public class OidcEndSessionResponse
{
    public string? RedirectUri { get; init; }
    public string? State { get; init; }
}