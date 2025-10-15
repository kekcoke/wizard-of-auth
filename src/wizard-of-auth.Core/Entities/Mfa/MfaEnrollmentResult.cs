using wizard_of_auth.Core.Enums;

namespace wizard_of_auth.Core.Entities.Mfa;

public class MfaEnrollmentResult
{
    public bool IsSuccess { get; init; }
    public MfaMethod Method { get; init; }
    public string? Secret { get; init; }
    public string? QrCodeUri { get; init; }
    public IReadOnlyList<string>? RecoveryCodes { get; init; }
    public string? ErrorMessage { get; init; }
}