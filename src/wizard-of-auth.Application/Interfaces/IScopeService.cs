using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Scope;

namespace wizard_of_auth.Application.Interfaces;

#region IScopeService - New

/// <summary>
/// OAuth 2.0 scope definition and validation service
/// </summary>
public interface IScopeService
{
    /// <summary>
    /// Gets scope definition by name
    /// </summary>
    Task<Scope?> GetScopeAsync(
        string scopeName,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets multiple scope definitions
    /// </summary>
    Task<IReadOnlyList<Scope>> GetScopesAsync(
        IEnumerable<string> scopeNames,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets all available scopes
    /// </summary>
    Task<IReadOnlyList<Scope>> GetAllScopesAsync(
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates requested scopes
    /// </summary>
    Task<ScopeValidationResult> ValidateScopesAsync(
        IEnumerable<string> requestedScopes,
        Guid? clientId = null,
        CancellationToken ct = default);
    
    /// <summary>
    /// Creates new scope
    /// </summary>
    Task<Result<Scope>> CreateScopeAsync(
        Scope scope,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates scope definition
    /// </summary>
    Task<Result<bool>> UpdateScopeAsync(
        Scope scope,
        CancellationToken ct = default);
    
    /// <summary>
    /// Deletes scope
    /// </summary>
    Task<Result<bool>> DeleteScopeAsync(
        string scopeName,
        CancellationToken ct = default);
}

#endregion