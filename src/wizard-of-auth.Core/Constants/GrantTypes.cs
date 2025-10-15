namespace wizard_of_auth.Core.Constants;

public static class GrantTypes
{
    public const string AuthorizationCode = "authorization_code";
    public const string RefreshToken = "refresh_token";
    public const string ClientCredentials = "client_credentials";
    public const string Password = "password"; // only if supported
}