using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Core.Interfaces;

#region IOpenIdConnectService - New

/// <summary>
/// OpenID Connect protocol implementation service
/// </summary>
public interface IOpenIdConnectService
{
    #region Discovery & Metadata
    
    /// <summary>
    /// Gets OpenID Connect discovery document (.well-known/openid-configuration)
    /// </summary>
    Task<OidcDiscoveryDocument> GetDiscoveryDocumentAsync(
        string issuer,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets JWKS (JSON Web Key Set) for token validation
    /// </summary>
    Task<string> GetJwksAsync(
        CancellationToken ct = default);
    
    #endregion
    
    #region Authentication Flow
    
    /// <summary>
    /// Handles OpenID Connect authentication request
    /// </summary>
    Task<Result<OidcAuthenticationResponse>> HandleAuthenticationRequestAsync(
        OidcAuthenticationRequest request,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates authentication request parameters
    /// </summary>
    Task<Result<bool>> ValidateAuthenticationRequestAsync(
        OidcAuthenticationRequest request,
        CancellationToken ct = default);
    
    #endregion
    
    #region Token Endpoint
    
    /// <summary>
    /// Handles token endpoint request
    /// </summary>
    Task<Result<TokenResponse>> HandleTokenRequestAsync(
        TokenRequest request,
        CancellationToken ct = default);
    
    #endregion
    
    #region UserInfo Endpoint
    
    /// <summary>
    /// Gets user information for authenticated user (UserInfo endpoint)
    /// </summary>
    Task<Result<OidcUserInfo>> GetUserInfoAsync(
        string accessToken,
        CancellationToken ct = default);
    
    #endregion
    
    #region Session Management
    
    /// <summary>
    /// Handles session management (check_session_iframe)
    /// </summary>
    Task<OidcSessionStatus> CheckSessionAsync(
        string sessionId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Handles end session request (logout)
    /// </summary>
    Task<Result<OidcEndSessionResponse>> HandleEndSessionRequestAsync(
        OidcEndSessionRequest request,
        CancellationToken ct = default);
    
    #endregion
    
    #region Dynamic Client Registration (Optional)
    
    /// <summary>
    /// Registers client dynamically (RFC 7591)
    /// </summary>
    Task<Result<OidcClientRegistrationResponse>> RegisterClientAsync(
        OidcClientRegistrationRequest request,
        CancellationToken ct = default);
    
    #endregion
}

#endregion