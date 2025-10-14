using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Authentication;
using wizard_of_auth.Core.Entities.IdentityConnector;
using wizard_of_auth.Core.Entities.Mfa;
using wizard_of_auth.Core.Enums;
using wizard_of_auth.Core.ValueObjects;

namespace wizard_of_auth.Core.Interfaces;

#region IIdentityConnector - Enhanced

/// <summary>
/// Interface for identity providers (internal, LDAP, Azure AD, etc.)
/// Supports authentication, MFA, and user synchronization
/// </summary>
public interface IIdentityConnector
{
    /// <summary>
    /// Connector type identifier (e.g., "Internal", "LDAP", "AzureAD")
    /// </summary>
    string ConnectorType { get; }
    
    /// <summary>
    /// Unique connector instance identifier
    /// </summary>
    string ConnectorId { get; }
    
    #region Authentication
    
    /// <summary>
    /// Authenticates user with username and password
    /// </summary>
    Task<AuthenticationResult> AuthenticateAsync(
        EmailAddress email,
        SecurePassword password,
        CancellationToken ct = default);
    
    /// <summary>
    /// Authenticates using external token (for federated identity)
    /// </summary>
    Task<AuthenticationResult> AuthenticateWithTokenAsync(
        string externalToken,
        string tokenType,
        CancellationToken ct = default);
    
    #endregion
    
    #region User Management
    
    /// <summary>
    /// Registers new user in the identity provider
    /// </summary>
    Task<RegistrationResult> RegisterUserAsync(
        UserRegistrationRequest request,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates user information in identity provider
    /// </summary>
    Task<Result<bool>> UpdateUserAsync(
        Guid userId,
        UserUpdateRequest request,
        CancellationToken ct = default);
    
    /// <summary>
    /// Deletes or disables user in identity provider
    /// </summary>
    Task<Result<bool>> DeleteUserAsync(
        Guid userId,
        bool hardDelete = false,
        CancellationToken ct = default);
    
    /// <summary>
    /// Changes user password in identity provider
    /// </summary>
    Task<Result<bool>> ChangePasswordAsync(
        Guid userId,
        SecurePassword currentPassword,
        SecurePassword newPassword,
        CancellationToken ct = default);
    
    /// <summary>
    /// Resets user password (admin or forgot password flow)
    /// </summary>
    Task<Result<string>> ResetPasswordAsync(
        Guid userId,
        bool generateTemporary = true,
        CancellationToken ct = default);
    
    #endregion
    
    #region MFA Operations
    
    /// <summary>
    /// Enrolls user in MFA method
    /// </summary>
    Task<MfaEnrollmentResult> EnrollMfaAsync(
        Guid userId,
        MfaMethod method,
        CancellationToken ct = default);
    
    /// <summary>
    /// Verifies MFA code/challenge
    /// </summary>
    Task<MfaVerificationResult> VerifyMfaAsync(
        Guid userId,
        string mfaCode,
        MfaMethod method,
        string? sessionToken = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Disables MFA for user
    /// </summary>
    Task<Result<bool>> DisableMfaAsync(
        Guid userId,
        MfaMethod method,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets enrolled MFA methods for user
    /// </summary>
    Task<IReadOnlyList<MfaMethod>> GetEnrolledMfaMethodsAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Generates MFA recovery codes
    /// </summary>
    Task<Result<IReadOnlyList<string>>> GenerateRecoveryCodesAsync(
        Guid userId,
        int count = 10,
        CancellationToken ct = default);
    
    #endregion
    
    #region User Synchronization
    
    /// <summary>
    /// Synchronizes users from external identity provider
    /// </summary>
    Task<SyncResult> SyncUsersAsync(
        SyncOptions? options = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Synchronizes single user from external provider
    /// </summary>
    Task<Result<User>> SyncUserAsync(
        string externalUserId,
        CancellationToken ct = default);
    
    #endregion
    
    #region Health & Capabilities
    
    /// <summary>
    /// Validates connection to identity provider
    /// </summary>
    Task<Result<bool>> ValidateConnectionAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets connector capabilities
    /// </summary>
    Task<ConnectorCapabilities> GetCapabilitiesAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets connector health status
    /// </summary>
    Task<ConnectorHealthStatus> GetHealthStatusAsync(
        CancellationToken ct = default);
    
    #endregion
}

#endregion