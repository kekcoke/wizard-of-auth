using wizard_of_auth.Core.Enums;

namespace wizard_of_auth.Core.Entities.Device;

/// <summary>
/// Result of device code polling
/// </summary>
public class DeviceCodePollResult
{
    public DeviceCodeStatus Status { get; init; }
    public string? AccessToken { get; init; }
    public string? RefreshToken { get; init; }
    public string? IdToken { get; init; }
    public int? ExpiresIn { get; init; }
    public string? ErrorCode { get; init; }
    public string? ErrorDescription { get; init; }
}