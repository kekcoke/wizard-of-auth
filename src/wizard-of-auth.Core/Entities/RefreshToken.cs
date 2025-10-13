using wizard_of_auth.Core.ValueObjects;

namespace wizard_of_auth.Core.Entities;

/// <summary>
/// A persistent refresh token entity.
/// Tracks token, user, client, creation and expiry details.
/// </summary>
public class RefreshToken
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    
    // Embedded value object
    public RefreshTokenValue Token { get; private set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public string? ReplacedByToken { get; set; }

    public User User { get; set; } = null!;
    public Client Client { get; set; } = null!;

    private RefreshToken() { } // EF or serialization only
    
    public RefreshToken(Guid userId, Guid clientId, RefreshTokenValue token)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ClientId = clientId;
        Token = token ?? throw new ArgumentNullException(nameof(token));
        CreatedAt = DateTime.UtcNow;
        ExpiresAt = token.ExpiresAt;
        IsUsed = false;
        IsRevoked = false;
    }
    
    public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;
    
    public void Revoke(string? replacedByToken = null)
    {
        IsRevoked = true;
        ReplacedByToken = replacedByToken;
        RevokedAt = DateTime.UtcNow;
    }
    
    public void MarkAsUsed()
    {
        if (IsUsed)
            throw new InvalidOperationException("Refresh token is already marked as used.");
        
        IsUsed = true;
    }
}