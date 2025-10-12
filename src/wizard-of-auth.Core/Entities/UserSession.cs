namespace wizard_of_auth.Core.Entities;

public class UserSession
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    // public string ClientId { get; set; } = string.Empty;
    public string SessionToken { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string UserAgent { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime? LastActivityAt { get; set; }
    public bool IsActive { get; set; }
}