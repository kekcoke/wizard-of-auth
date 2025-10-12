namespace wizard_of_auth.Core.Entities;

public class AuthorizationCode
{
    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public Guid UserId { get; set; }
    public string ClientId { get; set; } = string.Empty;
    public string RedirectUri { get; set; } = string.Empty;
    public List<string> Scopes { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsUsed { get; set; }
    
    // PKCE
    public string? CodeChallenge { get; set; }
    public string? CodeChallengeMethod { get; set; } // "plain" or "S256"
    
    public User User { get; set; } = null!;
    public Client Client { get; set; } = null!;
}