using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Enums.Auth;

namespace wizard_of_auth.Core.Interfaces;

#region ISessionService - New

/// <summary>
/// User session management service
/// </summary>
public interface ISessionService
{
    /// <summary>
    /// Creates new user session
    /// </summary>
    Task<Result<Session>> CreateSessionAsync(
        Guid userId,
        string ipAddress,
        string userAgent,
        AuthenticationMethod method,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets session by ID
    /// </summary>
    Task<Session?> GetSessionAsync(
        string sessionId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Validates session is active
    /// </summary>
    Task<bool> ValidateSessionAsync(
        string sessionId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Updates session last activity
    /// </summary>
    Task UpdateSessionActivityAsync(
        string sessionId,
        CancellationToken ct = default);
    
    /// <summary>
    /// Terminates specific session
    /// </summary>
    Task<Result<bool>> TerminateSessionAsync(
        string sessionId,
        SessionTerminationReason reason,
        CancellationToken ct = default);
    
    /// <summary>
    /// Gets all active sessions for user
    /// </summary>
    Task<IReadOnlyList<Session>> GetSessionsAsync(
        Guid userId,
        bool includeExpired = false,
        CancellationToken ct = default);
    
    /// <summary>
    /// Terminates all sessions for user (logout everywhere)
    /// </summary>
    Task<Result<int>> TerminateAllSessionsAsync(
        Guid userId,
        string? exceptSessionId = null,
        SessionTerminationReason reason = SessionTerminationReason.UserInitiated,
        CancellationToken ct = default);
    
    /// <summary>
    /// Prunes expired sessions
    /// </summary>
    Task<int> PruneExpiredSessionsAsync(
        DateTime olderThan,
        CancellationToken ct = default);
}

#endregion