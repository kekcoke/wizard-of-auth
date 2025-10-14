namespace wizard_of_auth.Core.Entities.Certificates;

/// <summary>
/// Individual certificate information
/// </summary>
public class CertificateInfo
{
    public string KeyId { get; init; } = string.Empty;
    public string Thumbprint { get; init; } = string.Empty;
    public string Algorithm { get; init; } = string.Empty;
    public DateTime ValidFrom { get; init; }
    public DateTime ValidUntil { get; init; }
    public CertificateUsage Usage { get; init; }
    public bool IsActive { get; init; }
    public bool IsExpired { get; init; }
}