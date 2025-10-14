using wizard_of_auth.Core.Entities.Audit;
using wizard_of_auth.Core.Entities.Authentication;
using wizard_of_auth.Core.Enums;
using wizard_of_auth.Core.Enums.Actions;
using wizard_of_auth.Core.Enums.Actions.Token;
using wizard_of_auth.Core.Enums.Auth;
using wizard_of_auth.Core.ValueObjects;

namespace wizard_of_auth.Core.Interfaces;

/// <summary>
/// Comprehensive audit logging for security, compliance, and forensics.
/// Implements logging for OAuth 2.0, OpenID Connect, and SAML 2.0 flows.
/// </summary>
public interface IAuditLogger
{
    #region Authentication Events
    
    /// <summary>
    /// Logs successful authentication (login)
    /// </summary>
    Task<AuditLogResult> LogSuccessfulLoginAsync(
        Guid userId,
        string ipAddress,
        string userAgent,
        AuthenticationMethod method,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs failed authentication attempt
    /// </summary>
    Task<AuditLogResult> LogFailedLoginAsync(
        EmailAddress? email,
        Guid? userId,
        string ipAddress,
        string userAgent,
        AuthenticationFailureReason reason,
        string? additionalDetails = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs user logout event
    /// </summary>
    Task<AuditLogResult> LogLogoutAsync(
        Guid userId,
        string ipAddress,
        LogoutReason reason,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs account lockout due to failed attempts
    /// </summary>
    Task<AuditLogResult> LogAccountLockoutAsync(
        Guid userId,
        string ipAddress,
        int failedAttempts,
        DateTime lockedUntil,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Token Events
    
    /// <summary>
    /// Logs token issuance (access, refresh, ID tokens)
    /// </summary>
    Task<AuditLogResult> LogTokenIssuanceAsync(
        Guid subjectId,
        Guid clientId,
        OAuth2GrantType grantType,
        IReadOnlyCollection<string> scopes,
        TokenType tokenType,
        string? tokenId = null,
        string? ipAddress = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs token refresh operation
    /// </summary>
    Task<AuditLogResult> LogTokenRefreshAsync(
        Guid userId,
        Guid clientId,
        string oldTokenId,
        string newTokenId,
        string ipAddress,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs token revocation
    /// </summary>
    Task<AuditLogResult> LogTokenRevocationAsync(
        Guid? userId,
        Guid? clientId,
        string tokenId,
        TokenRevocationReason reason,
        string? revokedBy = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs failed token validation
    /// </summary>
    Task<AuditLogResult> LogTokenValidationFailureAsync(
        string tokenId,
        string ipAddress,
        TokenValidationFailureReason reason,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Authorization Events (OAuth 2.0)
    
    /// <summary>
    /// Logs authorization code issuance
    /// </summary>
    Task<AuditLogResult> LogAuthorizationCodeIssuedAsync(
        Guid userId,
        Guid clientId,
        string codeId,
        IReadOnlyCollection<string> scopes,
        string redirectUri,
        string? state = null,
        string? nonce = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs authorization code exchange
    /// </summary>
    Task<AuditLogResult> LogAuthorizationCodeExchangedAsync(
        string codeId,
        Guid clientId,
        bool success,
        string? failureReason = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs user consent granted/denied
    /// </summary>
    Task<AuditLogResult> LogConsentDecisionAsync(
        Guid userId,
        Guid clientId,
        IReadOnlyCollection<string> scopes,
        bool granted,
        string ipAddress,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region OpenID Connect Events
    
    /// <summary>
    /// Logs OpenID Connect authentication request
    /// </summary>
    Task<AuditLogResult> LogOidcAuthenticationRequestAsync(
        Guid? userId,
        Guid clientId,
        string responseType,
        IReadOnlyCollection<string> scopes,
        string? nonce = null,
        string? state = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs ID token issuance
    /// </summary>
    Task<AuditLogResult> LogIdTokenIssuanceAsync(
        Guid userId,
        Guid clientId,
        string tokenId,
        string? nonce = null,
        IReadOnlyCollection<string>? claims = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs UserInfo endpoint access
    /// </summary>
    Task<AuditLogResult> LogUserInfoAccessAsync(
        Guid userId,
        Guid clientId,
        string ipAddress,
        IReadOnlyCollection<string> claimsReturned,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region SAML Events
    
    /// <summary>
    /// Logs SAML authentication request received
    /// </summary>
    Task<AuditLogResult> LogSamlAuthenticationRequestAsync(
        string requestId,
        string issuer,
        string? destination = null,
        string? assertionConsumerServiceUrl = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs SAML response generation
    /// </summary>
    Task<AuditLogResult> LogSamlResponseIssuedAsync(
        Guid userId,
        string requestId,
        string responseId,
        string recipient,
        bool success,
        IReadOnlyCollection<string>? attributes = null,
        string? failureReason = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs SAML logout request
    /// </summary>
    Task<AuditLogResult> LogSamlLogoutRequestAsync(
        Guid? userId,
        string requestId,
        string issuer,
        SamlLogoutType logoutType,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region MFA Events
    
    /// <summary>
    /// Logs MFA enrollment
    /// </summary>
    Task<AuditLogResult> LogMfaEnrollmentAsync(
        Guid userId,
        MfaMethod method,
        string ipAddress,
        bool success,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs MFA verification attempt
    /// </summary>
    Task<AuditLogResult> LogMfaVerificationAsync(
        Guid userId,
        MfaMethod method,
        bool success,
        string ipAddress,
        MfaFailureReason? failureReason = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs MFA method disabled/removed
    /// </summary>
    Task<AuditLogResult> LogMfaDisabledAsync(
        Guid userId,
        MfaMethod method,
        string ipAddress,
        Guid? performedBy = null,
        string? reason = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Administrative Actions
    
    /// <summary>
    /// Logs password change/reset
    /// </summary>
    Task<AuditLogResult> LogPasswordChangeAsync(
        Guid userId,
        Guid? performedBy,
        PasswordChangeReason reason,
        string ipAddress,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs administrative action affecting security state
    /// </summary>
    Task<AuditLogResult> LogAdminActionAsync(
        Guid adminId,
        Guid? targetUserId,
        AdminActionType actionType,
        string actionDetails,
        string ipAddress,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs security policy changes
    /// </summary>
    Task<AuditLogResult> LogSecurityPolicyChangeAsync(
        Guid adminId,
        string policyName,
        string changeDescription,
        string oldValue,
        string newValue,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Suspicious Activity
    
    /// <summary>
    /// Logs unauthorized access attempts
    /// </summary>
    Task<AuditLogResult> LogUnauthorizedAccessAttemptAsync(
        string ipAddress,
        string requestPath,
        string? userId = null,
        string? reason = null,
        string? correlationId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Logs potential security threats
    /// </summary>
    Task<AuditLogResult> LogSecurityThreatAsync(
        string threatType,
        string description,
        string ipAddress,
        Guid? userId = null,
        ThreatSeverity severity = ThreatSeverity.Medium,
        string? correlationId = null,
        CancellationToken ct = default);
    
    #endregion
    
    #region Query Methods
    
    /// <summary>
    /// Retrieves audit logs with filtering
    /// </summary>
    Task<PagedResult<AuditLogEntry>> GetAuditLogsAsync(
        AuditLogFilter filter,
        int page,
        int pageSize,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets audit trail for specific user
    /// </summary>
    Task<IReadOnlyList<AuditLogEntry>> GetUserAuditTrailAsync(
        Guid userId,
        DateTime? from = null,
        DateTime? to = null,
        CancellationToken ct = default);
    
    #endregion
}