namespace wizard_of_auth.Core.Enums;

/// <summary>
/// Defines the various Multi-Factor Authentication (MFA) methods available.
/// </summary>
public enum MfaMethod
{
    Totp = 1,
    Sms = 2,
    Email = 3,
    SecurityKey = 4,
    PushNotification = 5,
    Biometric = 6,
    PhoneCall = 7,
    BackupCodes = 8
}