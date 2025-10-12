namespace wizard_of_auth.Core.Entities;

public class Token
{
    public Guid Id { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // AccessToken, RefreshToken, etc.
    public Guid UserId { get; set; }
    public string ClientId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime? RevokedAt { get; set; }
    public List<string> Scopes { get; set; } = new();

    public User User { get; set; } = null!;
    public Client Client { get; set; } = null!;
}
