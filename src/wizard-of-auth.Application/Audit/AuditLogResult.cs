namespace wizard_of_auth.Application.Audit;

/// <summary>
/// Audit log entry result
/// </summary>
public class AuditLogResult
{
    public bool IsSuccess { get; init; }
    public Guid? LogEntryId { get; init; }
    public string? ErrorMessage { get; init; }
}