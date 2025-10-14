public class OidcDiscoveryDocument
{
    public string Issuer { get; init; } = string.Empty;
    public string AuthorizationEndpoint { get; init; } = string.Empty;
    public string TokenEndpoint { get; init; } = string.Empty;
    public string UserInfoEndpoint { get; init; } = string.Empty;
    public string JwksUri { get; init; } = string.Empty;
    public string? RegistrationEndpoint { get; init; }
    public string? EndSessionEndpoint { get; init; }
    public string? CheckSessionIframe { get; init; }
    public string? RevocationEndpoint { get; init; }
    public string? IntrospectionEndpoint { get; init; }
    public IReadOnlyList<string> ScopesSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> ResponseTypesSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> ResponseModesSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> GrantTypesSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> SubjectTypesSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> IdTokenSigningAlgValuesSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> TokenEndpointAuthMethodsSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> ClaimsSupported { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> CodeChallengeMethodsSupported { get; init; } = Array.Empty<string>();
}