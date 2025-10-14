using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Enums.Actions.Token;

namespace wizard_of_auth.Core.Interfaces;

#region IRefreshTokenRepository - New

/// <summary>
/// Repository for refresh token storage and management
/// </summary>
public interface IRefreshTokenRepository
{
    /// <summary>
    /// Stores a new refresh token
    /// </summary>
    Task<string> CreateAsync(
        RefreshToken token,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets refresh token by token value (hashed)
    /// </summary>
    Task<RefreshToken?> GetByTokenAsync(
        string tokenHash,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets refresh token by ID
    /// </summary>
    Task<RefreshToken?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default);
    
    /// <summary>
    /// Marks refresh token as used (for rotation detection)
    /// </summary>
    Task MarkAsUsedAsync(
        Guid tokenId,
        DateTime usedAt,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes a refresh token
    /// </summary>
    Task RevokeAsync(
        Guid tokenId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes entire refresh token family (for refresh token rotation)
    /// </summary>
    Task RevokeFamilyAsync(
        string familyId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes all refresh tokens for user
    /// </summary>
    Task RevokeAllForUserAsync(
        Guid userId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes all refresh tokens for client
    /// </summary>
    Task RevokeAllForClientAsync(
        Guid clientId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes all refresh tokens for user-client combination
    /// </summary>
    Task RevokeAllForUserClientAsync(
        Guid userId,
        Guid clientId,
        TokenRevocationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets active refresh tokens for user
    /// </summary>
    Task<IReadOnlyList<RefreshToken>> GetActiveTokensForUserAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Prunes expired tokens
    /// </summary>
    Task<int> PruneExpiredTokensAsync(
        DateTime olderThan,
        CancellationToken ct = default);
}

#endregion