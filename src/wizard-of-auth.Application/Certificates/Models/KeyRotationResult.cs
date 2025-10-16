using wizard_of_auth.Core.Enums.Certificates;

namespace wizard_of_auth.Application.Certificates.Models;

/// <summary>
/// Key rotation result
/// </summary>
public class KeyRotationResult
{
    public string RotationId { get; init; } = string.Empty;
    public string NewKeyId { get; init; } = string.Empty;
    public string OldKeyId { get; init; } = string.Empty;
    public DateTime RotationStarted { get; init; }
    public DateTime OverlapEndsAt { get; init; }
    public KeyRotationStatus Status { get; init; }
}