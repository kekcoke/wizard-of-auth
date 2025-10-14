public class RegistrationResult
{
    public bool IsSuccess { get; init; }
    public Guid? UserId { get; init; }
    public string? ErrorCode { get; init; }
    public string? ErrorMessage { get; init; }
    public bool RequiresEmailVerification { get; init; }
    public bool RequiresAdminApproval { get; init; }
}