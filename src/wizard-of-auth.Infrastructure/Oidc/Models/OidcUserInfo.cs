namespace wizard_of_auth.Infrastructure.Oidc.Models;

public class OidcUserInfo
{
    public string Sub { get; init; } = string.Empty;
    public string? Name { get; init; }
    public string? GivenName { get; init; }
    public string? FamilyName { get; init; }
    public string? MiddleName { get; init; }
    public string? Nickname { get; init; }
    public string? PreferredUsername { get; init; }
    public string? Profile { get; init; }
    public string? Picture { get; init; }
    public string? Website { get; init; }
    public string? Email { get; init; }
    public bool? EmailVerified { get; init; }
    public string? Gender { get; init; }
    public string? Birthdate { get; init; }
    public string? Zoneinfo { get; init; }
    public string? Locale { get; init; }
    public string? PhoneNumber { get; init; }
    public bool? PhoneNumberVerified { get; init; }
    public Dictionary<string, object>? AdditionalClaims { get; init; }
}