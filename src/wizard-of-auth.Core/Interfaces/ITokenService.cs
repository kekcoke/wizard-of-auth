using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Authentication;
using wizard_of_auth.Core.Entities.Authorization;
using wizard_of_auth.Core.Entities.Device;
using wizard_of_auth.Core.Enums.Actions.Token;

namespace wizard_of_auth.Core.Interfaces;

/// <summary>
/// Comprehensive token service supporting OAuth 2.0, OpenID Connect, and custom token types
/// </summary>
public interface ITokenService
{
    #region Access Token Operations
    
    /// <summary>
    /// Generates an OAuth 2.0 access token
    /// </summary>
    Task<Result<AccessTokenResult>> GenerateAccessTokenAsync(
        Guid userId,
        Guid clientId,
        IEnumerable<string> scopes,
        TokenOptions? options = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates an access token and returns claims
    /// </summary>
    Task<TokenValidationResult> ValidateAccessTokenAsync(
        string token,
        TokenValidationParameters? parameters = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Refresh Token Operations
    
    /// <summary>
    /// Generates a refresh token
    /// </summary>
    Task<Result<RefreshTokenResult>> GenerateRefreshTokenAsync(
        Guid userId,
        Guid clientId,
        string? deviceId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates and consumes a refresh token, optionally rotating it
    /// </summary>
    Task<Result<TokensRefreshResult>> RefreshAccessTokenAsync(
        string refreshToken,
        Guid clientId,
        bool rotateRefreshToken = true,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates refresh token without consuming it
    /// </summary>
    Task<TokenValidationResult> ValidateRefreshTokenAsync(
        string refreshToken,
        CancellationToken ct = default);
    
    #endregion
    
    #region OpenID Connect - ID Token
    
    /// <summary>
    /// Generates an OpenID Connect ID Token (JWT)
    /// </summary>
    Task<Result<string>> GenerateIdTokenAsync(
        Guid userId,
        Guid clientId,
        string nonce,
        IEnumerable<string> scopes,
        string? accessTokenHash = null,
        string? authorizationCodeHash = null,
        IdTokenOptions? options = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates an ID token
    /// </summary>
    Task<TokenValidationResult> ValidateIdTokenAsync(
        string idToken,
        string? nonce = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Authorization Code Operations
    
    /// <summary>
    /// Generates an authorization code for OAuth 2.0 authorization code flow
    /// </summary>
    Task<Result<string>> GenerateAuthorizationCodeAsync(
        Guid userId,
        Guid clientId,
        string redirectUri,
        IEnumerable<string> scopes,
        string? state = null,
        string? nonce = null,
        string? codeChallenge = null,
        string? codeChallengeMethod = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates and exchanges authorization code for tokens
    /// </summary>
    Task<Result<AuthorizationCodeExchangeResult>> ExchangeAuthorizationCodeAsync(
        string code,
        Guid clientId,
        string redirectUri,
        string? codeVerifier = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Device Code Flow (OAuth 2.0)
    
    /// <summary>
    /// Initiates device authorization flow
    /// </summary>
    Task<Result<DeviceAuthorizationResult>> InitiateDeviceAuthorizationAsync(
        Guid clientId,
        IEnumerable<string> scopes,
        CancellationToken ct = default);
    
    /// <summary>
    /// Polls for device code authorization status
    /// </summary>
    Task<Result<DeviceCodePollResult>> PollDeviceCodeAsync(
        string deviceCode,
        Guid clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Completes device authorization (user approves)
    /// </summary>
    Task<Result<bool>> CompleteDeviceAuthorizationAsync(
        string userCode,
        Guid userId,
        bool approved,
        CancellationToken ct = default);
    
    #endregion
    
    #region Token Introspection (RFC 7662)
    
    /// <summary>
    /// Introspects a token (OAuth 2.0 Token Introspection)
    /// </summary>
    Task<TokenIntrospectionResult> IntrospectTokenAsync(
        string token,
        string? tokenTypeHint = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Token Revocation (RFC 7009)
    
    /// <summary>
    /// Revokes a specific token
    /// </summary>
    Task<Result<bool>> RevokeTokenAsync(
        string token,
        string? tokenTypeHint = null,
        TokenRevocationReason reason = TokenRevocationReason.UserRequest,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes all tokens for a user
    /// </summary>
    Task<Result<int>> RevokeAllUserTokensAsync(
        Guid userId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes all tokens for a client
    /// </summary>
    Task<Result<int>> RevokeAllClientTokensAsync(
        Guid clientId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes tokens for user-client combination
    /// </summary>
    Task<Result<int>> RevokeUserClientTokensAsync(
        Guid userId,
        Guid clientId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    #endregion
    
    #region Token Management
    
    /// <summary>
    /// Gets active tokens for a user
    /// </summary>
    Task<IReadOnlyList<ActiveTokenInfo>> GetActiveTokensAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Prunes expired tokens from storage
    /// </summary>
    Task<Result<int>> PruneExpiredTokensAsync(
        DateTime? olderThan = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets token statistics for monitoring
    /// </summary>
    Task<TokenStatistics> GetTokenStatisticsAsync(
        DateTime? from = null,
        DateTime? to = null,
        CancellationToken ct = default);
    
    #endregion
}