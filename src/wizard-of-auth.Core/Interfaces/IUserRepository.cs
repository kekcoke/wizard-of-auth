using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Core.Interfaces;

public interface IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);
    public Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
    public Task<User?> GetByEmailAndTenantAsync(string email, Guid tenantId, CancellationToken ct = default);
    public Task<User> CreateAsync(User user, CancellationToken ct = default);
    public Task UpdateAsync(User user, CancellationToken ct = default);
    public Task DeleteAsync(Guid id, CancellationToken ct = default);
    public Task<bool> ExistsAsync(string email, CancellationToken ct = default);
}