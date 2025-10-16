using wizard_of_auth.Application.Consent.Models;
using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Consent;

namespace wizard_of_auth.Application.Interfaces;

# region IConsentService - New

/// <summary>
/// User consent management for OAuth 2.0 and OpenID Connect
/// </summary>
public interface IConsentService
{
    /// <summary>
    /// Records user consent for client application
    /// </summary>
    Task<Result<Guid>> RecordConsentAsync(
        Guid userId,
        Guid clientId,
        IEnumerable<string> scopes,
        DateTime? expiresAt = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Checks if user has already consented to requested scopes
    /// </summary>
    Task<ConsentCheckResult> CheckConsentAsync(
        Guid userId,
        Guid clientId,
        IEnumerable<string> requestedScopes,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets all consents for user
    /// </summary>
    Task<IReadOnlyList<UserConsent>> GetUserConsentsAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes consent for specific client
    /// </summary>
    Task<Result<bool>> RevokeConsentAsync(
        Guid userId,
        Guid clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes all consents for user
    /// </summary>
    Task<Result<int>> RevokeAllUserConsentsAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates consent (add/remove scopes)
    /// </summary>
    Task<Result<bool>> UpdateConsentAsync(
        Guid consentId,
        IEnumerable<string> scopes,
        CancellationToken ct = default);
    
    /// <summary>
    /// Prunes expired consents
    /// </summary>
    Task<int> PruneExpiredConsentsAsync(
        CancellationToken ct = default);
}

#endregion