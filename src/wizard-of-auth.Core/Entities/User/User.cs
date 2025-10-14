namespace wizard_of_auth.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public Guid TenantId { get; set; }
    public string Email { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreatedAt { get; private set; }
    public bool EmailVerified { get; private set; }
    public bool MfaEnabled { get; private set; }
    public List<string> MfaMethods { get; private set; }
    public DateTime? LastLoginAt { get; private set; }
    public int FailedLoginAttempts { get; private set; }
    public bool IsLocked { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Session> Sessions { get; set; }
    public string PasswordHash { get; private set; }
    
    // Private constructor for EF Core or controlled creation
    private User(Guid id, 
        string email, 
        string firstName,
        string lastName,
        string phoneNumber,
        string passwordHash)
    
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
        EmailVerified = false;
        MfaEnabled = false;
        MfaMethods = new List<string>();
        CreatedAt = DateTime.UtcNow;
        FailedLoginAttempts = 0;
        IsDeleted = false;
        Sessions = new List<Session>();
    }
    
    // Static to keep domain logic clean
    public static User Create(string email, string firstName, string lastName, string phoneNumber, string passwordHash)
    {
        return new User(Guid.NewGuid(), email, firstName, lastName, phoneNumber, passwordHash);
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
