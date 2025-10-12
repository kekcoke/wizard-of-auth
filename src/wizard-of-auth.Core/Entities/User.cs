namespace wizard_of_auth.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool EmailVerified { get; private set; }
    public bool MfaEnabled { get; private set; }
    public List<string> MfaMethods { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }
    public bool IsLocked { get; private set; }
    public int FailedLoginAttempts { get; private set; }
    
    public bool IsDeleted { get; private set; }
    
    // Private constructor for EF Core or controlled creation
    private User(Guid id, string email, string passwordHash)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        EmailVerified = false;
        MfaEnabled = false;
        MfaMethods = new List<string>();
        CreatedAt = DateTime.UtcNow;
        FailedLoginAttempts = 0;
        IsDeleted = false;
    }
    
    // Static to keep domain logic clean
    public static User Create(string email, string passwordHash)
    {
        return new User(Guid.NewGuid(), email, passwordHash);
    }

    public void RecordSuccessfulLogin()
    {
        LastLoginAt = DateTime.UtcNow;
        FailedLoginAttempts = 0;
        IsLocked = false;
    }

    public void RecordFailedLogin(int maxAttempts = 5)
    {
        FailedLoginAttempts++;
        if (FailedLoginAttempts >= maxAttempts)
        {
            IsLocked = true;
        }
    }
}
