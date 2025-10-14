using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Audit;
using wizard_of_auth.Core.ValueObjects;

namespace wizard_of_auth.Core.Interfaces;

#region IClientRepository - Enhanced

/// <summary>
/// Repository for OAuth 2.0/OIDC client applications
/// </summary>
public interface IClientRepository
{
    #region Basic CRUD
    
    /// <summary>
    /// Gets client by internal ID
    /// </summary>
    Task<Client?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets client by client_id (OAuth 2.0 identifier)
    /// </summary>
    Task<Client?> GetByClientIdAsync(
        string clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets all clients for a tenant
    /// </summary>
    Task<PagedResult<Client>> GetByTenantAsync(
        Guid tenantId,
        int page,
        int pageSize,
        bool includeInactive = false,
        CancellationToken ct = default);
    
    /// <summary>
    /// Creates new client
    /// </summary>
    Task<Client> CreateAsync(
        Client client,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates existing client
    /// </summary>
    Task UpdateAsync(
        Client client,
        CancellationToken ct = default);
    
    /// <summary>
    /// Soft deletes client
    /// </summary>
    Task DeleteAsync(
        Guid id,
        CancellationToken ct = default);
    
    #endregion
    
    #region Authentication & Validation
    
    /// <summary>
    /// Validates client credentials (for confidential clients)
    /// </summary>
    Task<Result<Client>> ValidateClientCredentialsAsync(
        string clientId,
        ClientSecret clientSecret,
        CancellationToken ct = default);
    
    /// <summary>
    /// Checks if client is active and enabled
    /// </summary>
    Task<bool> IsActiveAsync(
        string clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates redirect URI for client
    /// </summary>
    Task<bool> ValidateRedirectUriAsync(
        string clientId,
        string redirectUri,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates that client supports requested grant type
    /// </summary>
    Task<bool> SupportsGrantTypeAsync(
        string clientId,
        string grantType,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates requested scopes for client
    /// </summary>
    Task<Result<IReadOnlyList<string>>> ValidateScopesAsync(
        string clientId,
        IEnumerable<string> requestedScopes,
        CancellationToken ct = default);
    
    #endregion
    
    #region Configuration Queries
    
    /// <summary>
    /// Gets allowed grant types for client
    /// </summary>
    Task<IReadOnlyList<string>> GetGrantTypesAsync(
        string clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets allowed scopes for client
    /// </summary>
    Task<IReadOnlyList<string>> GetAllowedScopesAsync(
        string clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets registered redirect URIs
    /// </summary>
    Task<IReadOnlyList<string>> GetRedirectUrisAsync(
        string clientId,
        CancellationToken ct = default);
    
    #endregion
    
    #region Secret Management
    
    /// <summary>
    /// Rotates client secret
    /// </summary>
    Task<string> RotateClientSecretAsync(
        Guid clientId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Revokes a specific client secret (for multi-secret clients)
    /// </summary>
    Task RevokeClientSecretAsync(
        Guid clientId,
        string secretId,
        CancellationToken ct = default);
    
    #endregion
}

#endregion