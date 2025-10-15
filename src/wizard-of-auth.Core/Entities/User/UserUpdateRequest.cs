public class UserUpdateRequest
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? PhoneNumber { get; init; }
    public bool? EmailVerified { get; init; }
    public bool? PhoneNumberVerified { get; init; }
    public Dictionary<string, object>? AdditionalAttributes { get; init; }
}