public class OidcClientRegistrationResponse
{
    public string ClientId { get; init; } = string.Empty;
    public string? ClientSecret { get; init; }
    public DateTime ClientIdIssuedAt { get; init; }
    public DateTime? ClientSecretExpiresAt { get; init; }
}