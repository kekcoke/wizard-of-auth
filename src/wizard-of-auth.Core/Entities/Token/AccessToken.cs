namespace wizard_of_auth.Core.Entities;

/// <summary>
/// Represents a persistent Access Token entity.
/// Tracks token hash, user, client, creation, and expiry details.
/// </summary>
public class AccessToken : TokenBase
{
    // The actual token string should likely not be stored.
    // We'll store a hash or a unique identifier from the token's payload (e.g., JTI)
    public string TokenHash { get; init; } = string.Empty; 
    
    // Added from original Token.cs but renamed for clarity (JTI is common)
    public string? Jti { get; init; } // JWT ID for revocation checks
    
    // Removed 'Value' (raw token string) and 'Type' (redundant with class name).
    
    public AccessToken(Guid userId, Guid clientId, DateTime expiresAt, string tokenHash, string? jti, IReadOnlyList<string>? scopes = null)
        : base(userId, clientId, expiresAt, scopes)
    {
        TokenHash = tokenHash;
        Jti = jti;
    }
    
    private AccessToken() { }
}