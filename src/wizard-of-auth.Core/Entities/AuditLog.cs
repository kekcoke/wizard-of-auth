namespace wizard_of_auth.Core.Entities;

public class AuditLog
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
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