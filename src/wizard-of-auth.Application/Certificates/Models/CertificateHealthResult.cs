namespace wizard_of_auth.Application.Certificates.Models;

/// <summary>
/// Certificate health check result
/// </summary>
public class CertificateHealthResult
{
    public bool IsHealthy { get; init; }
    public IReadOnlyList<string> Warnings { get; init; } = Array.Empty<string>();
    public IReadOnlyList<string> Errors { get; init; } = Array.Empty<string>();
    public DateTime CheckedAt { get; init; }
}