namespace wizard_of_auth.Core.Enums.Actions.Token;

public enum TokenRevocationReason
{
    Expired,
    InvalidSignature,
    Revoked,
    InvalidIssuer,
    InvalidAudience,
    InvalidClaims,
    Malformed,
    UserRequest,
    CompromiseDetected
}