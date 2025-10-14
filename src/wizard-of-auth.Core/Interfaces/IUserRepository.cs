using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Audit;
using wizard_of_auth.Core.ValueObjects;

namespace wizard_of_auth.Core.Interfaces;
#region IUserRepository - Enhanced

/// <summary>
/// Repository for user management with multi-tenancy support
/// </summary>
public interface IUserRepository
{
    #region Basic CRUD
    
    /// <summary>
    /// Gets user by internal ID
    /// </summary>
    Task<User?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets user by email address
    /// </summary>
    Task<User?> GetByEmailAsync(
        EmailAddress email,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets user by email within specific tenant
    /// </summary>
    Task<User?> GetByEmailAndTenantAsync(
        EmailAddress email,
        Guid tenantId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets multiple users by IDs (bulk retrieval)
    /// </summary>
    Task<IReadOnlyList<User>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets user by external provider ID (for federated identity)
    /// </summary>
    Task<User?> GetByExternalProviderIdAsync(
        string providerId,
        string externalUserId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Creates a new user
    /// </summary>
    Task<User> CreateAsync(
        User user,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates existing user
    /// </summary>
    Task UpdateAsync(
        User user,
        CancellationToken ct = default);
    
    /// <summary>
    /// Soft deletes a user (marks as deleted but retains data)
    /// </summary>
    Task SoftDeleteAsync(
        Guid id,
        Guid? deletedBy = null,
        string? reason = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Permanently deletes user (GDPR compliance)
    /// </summary>
    Task HardDeleteAsync(
        Guid id,
        CancellationToken ct = default);
    
    #endregion
    
    #region Query Methods
    
    /// <summary>
    /// Searches users with advanced filtering
    /// </summary>
    Task<PagedResult<User>> SearchAsync(
        UserSearchCriteria criteria,
        int page,
        int pageSize,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets all users in a tenant with pagination
    /// </summary>
    Task<PagedResult<User>> GetByTenantAsync(
        Guid tenantId,
        int page,
        int pageSize,
        bool includeDeleted = false,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets users by role
    /// </summary>
    Task<PagedResult<User>> GetByRoleAsync(
        string roleName,
        Guid? tenantId = null,
        int page = 1,
        int pageSize = 50,
        CancellationToken ct = default);
    
    #endregion
    
    #region Existence Checks
    
    /// <summary>
    /// Checks if user with email exists
    /// </summary>
    Task<bool> ExistsAsync(
        EmailAddress email,
        CancellationToken ct = default);
    
    /// <summary>
    /// Checks if user exists in specific tenant
    /// </summary>
    Task<bool> ExistsInTenantAsync(
        EmailAddress email,
        Guid tenantId,
        CancellationToken ct = default);
    
    #endregion
    
    #region Statistics
    
    /// <summary>
    /// Gets user count for tenant
    /// </summary>
    Task<long> CountByTenantAsync(
        Guid tenantId,
        bool includeDeleted = false,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets total active users across all tenants
    /// </summary>
    Task<long> CountActiveUsersAsync(
        CancellationToken ct = default);
    
    #endregion
    
    #region Security Operations
    
    /// <summary>
    /// Updates user's last login timestamp
    /// </summary>
    Task UpdateLastLoginAsync(
        Guid userId,
        DateTime loginTime,
        string ipAddress,
        CancellationToken ct = default);
    
    /// <summary>
    /// Locks user account
    /// </summary>
    Task LockAccountAsync(
        Guid userId,
        DateTime? lockUntil = null,
        string? reason = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Unlocks user account
    /// </summary>
    Task UnlockAccountAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates failed login attempt counter
    /// </summary>
    Task IncrementFailedLoginAttemptsAsync(
        Guid userId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Resets failed login attempts counter
    /// </summary>
    Task ResetFailedLoginAttemptsAsync(
        Guid userId,
        CancellationToken ct = default);
    
    #endregion
}

#endregion