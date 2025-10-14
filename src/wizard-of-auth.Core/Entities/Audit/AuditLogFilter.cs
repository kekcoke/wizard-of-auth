namespace wizard_of_auth.Core.Entities.Audit;

public class AuditLogFilter
{
    public DateTime? FromDate { get; init; }
    public DateTime? ToDate { get; init; }
    public Guid? UserId { get; init; }
    public string? IpAddress { get; init; }
    public string? EventType { get; init; }
    public string? CorrelationId { get; init; }
}
