namespace wizard_of_auth.Infrastructure.Audit;

public class AuditLog
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid? UserId { get; set; }
    public string EventType { get; set; } = string.Empty;
    public string? IpAddress { get; set; } // add validation
    public string? UserAgent { get; set; } // add validation
    public string Details { get; set; } = "{}"; // JSON string for additional details
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public bool Success { get; set; }
    
    public string Action { get; set; }
    
    private List<string> Actions = new()
    {
        "UserLogin",
        "UserLogout",
        "UserCreated",
        "UserUpdated",
        "UserDeleted",
        "PasswordChanged",
        "PasswordResetRequested"
    };
    
    public AuditLog(string action)
    {
        if (!Actions.Contains(action))
        {
            throw new ArgumentException("Invalid action");
        }
        
        Action = action;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public bool IsActionValid(string action) => Actions.Contains(action);
}