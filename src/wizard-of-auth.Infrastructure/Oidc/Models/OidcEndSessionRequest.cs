using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Oidc.Models;

public class OidcEndSessionRequest
{
    public string? IdTokenHint { get; init; }
    public string? PostLogoutRedirectUri { get; init; }
    public string? State { get; init; }
    public SessionTerminationReason Reason { get; set; }
}