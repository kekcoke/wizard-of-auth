using Microsoft.EntityFrameworkCore;
using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Interfaces;
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
            .FirstOrDefaultAsync(c => c.ClientId == clientId, ct);
    }

    public async Task<Client?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Clients.FindAsync(new object[] { id }, ct);
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