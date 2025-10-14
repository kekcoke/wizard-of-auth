using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.ValueObjects;

namespace wizard_of_auth.Core.Interfaces;

public interface IIdentityConnector
{
    string ConnectorType { get; }
    Task<User?> AuthenticateAsync(EmailAddress username, string password, CancellationToken ct);
    Task RegisterUserAsync(EmailAddress email, CancellationToken ct);
    Task<bool> VerifyMfaAsync(Guid userId, string mfaCode, CancellationToken ct);
    Task<List<User>> SyncUsersAsync(CancellationToken ct);
    Task<bool> ValidateConnectionAsync(CancellationToken ct);
}