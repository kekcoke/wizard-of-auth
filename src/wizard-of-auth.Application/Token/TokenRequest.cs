namespace wizard_of_auth.Application.Token;

public class TokenRequest
{
    public string GrantType { get; init; } = string.Empty;
    public string? Code { get; init; }
    public string? RedirectUri { get; init; }
    public string ClientId { get; init; } = string.Empty;
    public string? ClientSecret { get; init; }
    public string? RefreshToken { get; init; }
    public string? Scope { get; init; }
    public string? CodeVerifier { get; init; }
    public string? ClientAssertion { get; init; }
    public string? ClientAssertionType { get; init; }
    public string? DeviceCode { get; init; }
}