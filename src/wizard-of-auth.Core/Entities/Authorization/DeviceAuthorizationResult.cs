namespace wizard_of_auth.Core.Entities.Authorization;

/// <summary>
/// Result of device authorization initiation
/// </summary>
public class DeviceAuthorizationResult
{
    public string DeviceCode { get; init; } = string.Empty;
    public string UserCode { get; init; } = string.Empty;
    public string VerificationUri { get; init; } = string.Empty;
    public string? VerificationUriComplete { get; init; }
    public int ExpiresIn { get; init; }
    public int Interval { get; init; } = 5;
}