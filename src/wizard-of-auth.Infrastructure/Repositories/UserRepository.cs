using Microsoft.EntityFrameworkCore;
using wizard_of_auth.Core.Entities;
using wizard_of_auth.Core.Entities.Audit;
using wizard_of_auth.Core.Interfaces;
using wizard_of_auth.Core.ValueObjects;
using wizard_of_auth.Infrastructure.Persistence;

namespace wizard_of_auth.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Users
            .Include(u => u.Sessions)
            .FirstOrDefaultAsync(u => u.Id == id, ct);
    }

    public Task<User?> GetByEmailAsync(EmailAddress email, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAndTenantAsync(EmailAddress email, Guid tenantId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<User>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByExternalProviderIdAsync(string providerId, string externalUserId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email.Value.ToLower() == email.ToLower(), ct);
    }

    public async Task<User?> GetByEmailAndTenantAsync(string email, Guid tenantId, CancellationToken ct = default)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => 
                u.Email.Value.ToLower() == email.ToLower() 
                && u.TenantId == tenantId, ct);
    }

    public async Task<User> CreateAsync(User user, CancellationToken ct = default)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(ct);
        return user;
    }

    public async Task UpdateAsync(User user, CancellationToken ct = default)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(ct);
    }

    public Task SoftDeleteAsync(Guid id, Guid? deletedBy = null, string? reason = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task HardDeleteAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<User>> SearchAsync(UserSearchCriteria criteria, int page, int pageSize, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<User>> GetByTenantAsync(Guid tenantId, int page, int pageSize, bool includeDeleted = false,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<User>> GetByRoleAsync(string roleName, Guid? tenantId = null, int page = 1, int pageSize = 50,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(EmailAddress email, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsInTenantAsync(EmailAddress email, Guid tenantId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<long> CountByTenantAsync(Guid tenantId, bool includeDeleted = false, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<long> CountActiveUsersAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateLastLoginAsync(Guid userId, DateTime loginTime, string ipAddress, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task LockAccountAsync(Guid userId, DateTime? lockUntil = null, string? reason = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task UnlockAccountAsync(Guid userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task IncrementFailedLoginAttemptsAsync(Guid userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task ResetFailedLoginAttemptsAsync(Guid userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var user = await GetByIdAsync(id, ct);
        if (user != null)
        {
            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(ct);
        }
    }

    public async Task<bool> ExistsAsync(string email, CancellationToken ct = default)
    {
        return await _context.Users.AnyAsync(u => u.Email.Value.ToLower() == email.ToLower(), ct);
    }
}