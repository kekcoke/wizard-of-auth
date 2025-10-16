namespace wizard_of_auth.Application.Token.Results;

/// <summary>
/// OAuth 2.0 Token Introspection result (RFC 7662)
/// </summary>
public class TokenIntrospectionResult
{
    public bool Active { get; init; }
    public string? Scope { get; init; }
    public Guid? ClientId { get; init; }
    public string? Username { get; init; }
    public string? TokenType { get; init; }
    public long? Exp { get; init; }
    public long? Iat { get; init; }
    public long? Nbf { get; init; }
    public string? Sub { get; init; }
    public string? Aud { get; init; }
    public string? Iss { get; init; }
    public string? Jti { get; init; }
    public Dictionary<string, object>? AdditionalClaims { get; init; }
}