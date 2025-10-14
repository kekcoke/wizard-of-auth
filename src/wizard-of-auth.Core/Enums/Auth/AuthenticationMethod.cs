namespace wizard_of_auth.Core.Enums.Auth;

public enum AuthenticationMethod
{
    UsernamePassword = 1,
    Certificate = 2,
    ApiKey = 3,
    WindowsIntegrated = 4,

    // Protocol-based methods
    OAuth2 = 10,
    OpenIdConnect = 11,
    Saml = 12
}