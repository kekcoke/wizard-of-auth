namespace wizard_of_auth.Infrastructure.Audit;

public class AuditLogEntry
{
    public Guid Id { get; init; }
    public DateTime Timestamp { get; init; }
    public string EventType { get; init; } = string.Empty;
    public Guid? UserId { get; init; }
    public string? IpAddress { get; init; }
    public string? UserAgent { get; init; }
    public string? CorrelationId { get; init; }
    public Dictionary<string, object> Metadata { get; init; } = new();
}