using Microsoft.EntityFrameworkCore;
using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Audit;
using wizard_of_auth.Core.Interfaces;
using wizard_of_auth.Core.ValueObjects;
using wizard_of_auth.Infrastructure.Persistence;

namespace wizard_of_auth.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Client?> GetByClientIdAsync(Guid clientId, CancellationToken ct = default)
    {
        return await _context.Clients
            .FirstOrDefaultAsync(c => c.Id == clientId, ct);
    }

    public async Task<Client?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Clients.FindAsync(new object[] { id }, ct);
    }

    public Task<Client?> GetByClientIdAsync(string clientId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<Client>> GetByTenantAsync(Guid tenantId, int page, int pageSize, bool includeInactive = false,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Client>> GetByTenantAsync(Guid tenantId, CancellationToken ct = default)
    {
        return await _context.Clients
            .Where(c => c.TenantId == tenantId)
            .ToListAsync(ct);
    }

    public async Task<Client> CreateAsync(Client client, CancellationToken ct = default)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync(ct);
        return client;
    }

    public async Task UpdateAsync(Client client, CancellationToken ct = default)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync(ct);
    }

    public Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Client>> ValidateClientCredentialsAsync(string clientId, ClientSecret clientSecret, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsActiveAsync(string clientId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateRedirectUriAsync(string clientId, string redirectUri, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SupportsGrantTypeAsync(string clientId, string grantType, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IReadOnlyList<string>>> ValidateScopesAsync(string clientId, IEnumerable<string> requestedScopes, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<string>> GetGrantTypesAsync(string clientId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<string>> GetAllowedScopesAsync(string clientId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<string>> GetRedirectUrisAsync(string clientId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> RotateClientSecretAsync(Guid clientId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task RevokeClientSecretAsync(Guid clientId, string secretId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ValidateClientCredentialsAsync(
        string clientId, 
        string clientSecret, 
        CancellationToken ct = default)
    {
        if (!Guid.TryParse(clientId, out var clientGuid))
            return false;
        var client = await GetByClientIdAsync(clientGuid, ct);
        return client != null && client.ClientSecret == clientSecret;
    }
}