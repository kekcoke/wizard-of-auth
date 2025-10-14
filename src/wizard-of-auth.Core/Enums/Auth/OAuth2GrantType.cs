namespace wizard_of_auth.Core.Enums;

public enum OAuth2GrantType
{
    AuthorizationCode = 1,
    AuthorizationCodeWithPKCE = 2,
    ClientCredentials = 3,
    DeviceCode = 4,
    [Obsolete("Implicit flow is deprecated in OAuth 2.1")]
    Implicit = 5,
    [Obsolete("Password grant is deprecated in OAuth 2.1")]
    Password = 6,
    RefreshToken = 7,
    None = 8
}