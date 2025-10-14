namespace wizard_of_auth.Core.Entities;

/// <summary>
/// Base class for persistent token entities (Access Token, Refresh Token, etc.).
/// Establishes common properties for consistency and base repository usage.
/// </summary>
public abstract class TokenBase
{
    // Identity & relationships
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    
    // Lifecycle & state
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; private set; }
    public DateTime? RevokedAt { get; private set; }
    
    // Authorization
    public IReadOnlyList<string> Scopes { get; init; } = Array.Empty<string>();
    
    // Navigation properties
    public User User { get; set; } = null!;
    public Client Client { get; set; } = null!;

    public TokenBase(Guid userId, Guid clientId, DateTime expiresAt, IReadOnlyList<string>? scopes = null)
    {
        UserId = userId;
        ClientId = clientId;
        ExpiresAt = expiresAt;
        Scopes = scopes ?? Array.Empty<string>();
    }

    protected TokenBase()
    { }
    
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    
    public virtual void Revoke()
    {
        if (IsRevoked)
            return;
        
        IsRevoked = true;
        RevokedAt = DateTime.UtcNow;
    }
    
}