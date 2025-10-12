using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Core.Interfaces;

public interface IIdentityConnector
{
    string ConnectorType { get; }
    Task<User?> AuthenticateAsync(string username, string password, CancellationToken ct);
    Task<List<User>> SyncUsersAsync(CancellationToken ct);
    Task<bool> ValidateConnectionAsync(CancellationToken ct);
}