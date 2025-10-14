using wizard_of_auth.Core.Entities.Certificates;

namespace wizard_of_auth.Core.Enums.Certificates;

/// <summary>
/// Certificate status information
/// </summary>
public class CertificateStatus
{
    public string CurrentKeyId { get; init; } = string.Empty;
    public DateTime CurrentKeyCreated { get; init; }
    public DateTime CurrentKeyExpires { get; init; }
    public int DaysUntilExpiration { get; init; }
    public bool IsRotationNeeded { get; init; }
    public bool IsRotationInProgress { get; init; }
    public IReadOnlyList<CertificateInfo> AllCertificates { get; init; } = Array.Empty<CertificateInfo>();
}