using wizard_of_auth.Core.ValueObjects;

public class UserRegistrationRequest
{
    public EmailAddress Email { get; init; } = null!;
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public SecurePassword? Password { get; init; }
    public string? PhoneNumber { get; init; }
    public Guid? TenantId { get; init; }
    public Dictionary<string, object>? AdditionalAttributes { get; init; }
}