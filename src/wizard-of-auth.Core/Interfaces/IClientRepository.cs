using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Core.Interfaces;

public interface IClientRepository
{
    public Task<Client?> GetByClientIdAsync(Guid clientId, CancellationToken ct = default);
    public Task<Client?> GetByIdAsync(Guid id , CancellationToken ct = default);
    public Task<List<Client>> GetByTenantAsync(Guid tenantId, CancellationToken ct = default);
    public Task<Client> CreateAsync(Client client, CancellationToken ct = default);
    public Task UpdateAsync(Client client, CancellationToken ct = default);
    public Task<bool> ValidateClientCredentialsAsync(string clientId, string clientSecret, CancellationToken ct = default);
}