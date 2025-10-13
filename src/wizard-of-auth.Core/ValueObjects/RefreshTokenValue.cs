namespace wizard_of_auth.Core.ValueObjects;

/// <summary>
/// Refresh token value and its expiry.
/// </summary>
public sealed record RefreshTokenValue
{
    public string Value { get; }
    public DateTime ExpiresAt { get; }

    public RefreshTokenValue(string value, DateTime expiresAt)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException("Refresh token value can't be empty", nameof(value));
        
        if (expiresAt <= DateTime.UtcNow)
            throw new ArgumentOutOfRangeException(nameof(expiresAt), "Refresh token expires can't be negative");
        
        Value = value;
        ExpiresAt = expiresAt;
    }
    
    /// <summary>
    /// Factory method to create a new refresh token value with a specified lifetime.
    /// </summary>
    /// <param name="value">The refresh token string.</param>
    /// <param name="expiry">The expiry date and time of the refresh token.</param>
    /// <returns>A new instance of <see cref="RefreshTokenValue"/>.</returns>
    public static RefreshTokenValue Create(string value, DateTime expiry) => new(value, expiry);
    
    /// <summary>
    /// Check if the refresh token is expired.
    /// </summary>
    public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;
    
    public override string ToString() => $"[TOKEN_VALUE] (Expires: {ExpiresAt:yyyy-MM-dd HH:mm:ss})";
}