public class OidcAuthenticationRequest
{
    public string ResponseType { get; init; } = string.Empty;
    public string ClientId { get; init; } = string.Empty;
    public string RedirectUri { get; init; } = string.Empty;
    public string Scope { get; init; } = string.Empty;
    public string? State { get; init; }
    public string? Nonce { get; init; }
    public string? ResponseMode { get; init; }
    public string? Display { get; init; }
    public string? Prompt { get; init; }
    public int? MaxAge { get; init; }
    public string? UiLocales { get; init; }
    public string? IdTokenHint { get; init; }
    public string? LoginHint { get; init; }
    public string? AcrValues { get; init; }
    public string? CodeChallenge { get; init; }
    public string? CodeChallengeMethod { get; init; }
}