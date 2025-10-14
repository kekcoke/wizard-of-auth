using wizard_of_auth.Core.Enums.Certificates;

namespace wizard_of_auth.Core.Entities.Certificates;

/// <summary>
/// Key rotation history entry
/// </summary>
public class KeyRotationHistory
{
    public string RotationId { get; init; } = string.Empty;
    public DateTime RotationDate { get; init; }
    public string OldKeyId { get; init; } = string.Empty;
    public string NewKeyId { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
    public Guid PerformedBy { get; init; }
    public KeyRotationStatus Status { get; init; }
}