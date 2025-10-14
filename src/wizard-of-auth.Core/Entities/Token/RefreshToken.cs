using wizard_of_auth.Core.Enums.Actions.Token;

namespace wizard_of_auth.Core.Entities;

/// <summary>
/// Represents a persistent Refresh Token entity.
/// Tracks lifecycle details, token family, and usage context.
/// </summary>
public class RefreshToken : TokenBase
{
    // Token Value
    // Using TokenHash from RefreshTokenNew.cs for security (never store raw token)
    public string TokenHash { get; init; } = string.Empty;
    
    // Token Family (from RefreshTokenNew.cs for "Rotating Refresh Tokens")
    // Allows revoking an entire chain of tokens.
    public string? FamilyId { get; init; } 
    
    // Usage and Revocation Tracking
    public DateTime? UsedAt { get; private set; } // Renamed from IsUsed (bool) to UsedAt (DateTime?)
    public string? ReplacedByTokenHash { get; set; } // From RefreshToken.cs (replaces ReplacedByToken string)
    public TokenRevocationReason? RevocationReason { get; private set; } // From RefreshTokenNew.cs
    
    // Contextual Data (from RefreshTokenNew.cs for security and logging)
    public string? DeviceId { get; init; }
    public string? IpAddress { get; init; }

    // Custom constructor
    public RefreshToken(
        Guid userId, 
        Guid clientId, 
        DateTime expiresAt, 
        string tokenHash, 
        string? familyId = null, 
        string? deviceId = null, 
        string? ipAddress = null,
        IReadOnlyList<string>? scopes = null)
        : base(userId, clientId, expiresAt, scopes)
    {
        TokenHash = tokenHash;
        FamilyId = familyId;
        DeviceId = deviceId;
        IpAddress = ipAddress;
    }

    // Default constructor for EF Core/serialization
    private RefreshToken() { }

    // Lifecycle methods
    public bool IsUsed => UsedAt.HasValue;
    
    public void MarkAsUsed(string? replacedByTokenHash = null)
    {
        if (UsedAt.HasValue)
            throw new InvalidOperationException("Refresh token is already marked as used.");
        
        UsedAt = DateTime.UtcNow;
        ReplacedByTokenHash = replacedByTokenHash;
    }
    
    public override void Revoke()
    {
        base.Revoke(); 
        // Default reason if not specified in an overload
        RevocationReason = TokenRevocationReason.CompromiseDetected; 
    }
    
    public void Revoke(TokenRevocationReason reason, string? replacedByTokenHash = null)
    {
        base.Revoke(); // Use base revocation logic
        RevocationReason = reason;
        
        // If it was revoked because a new token replaced it, capture that hash.
        if (replacedByTokenHash != null)
        {
             ReplacedByTokenHash = replacedByTokenHash;
        }
    }
}