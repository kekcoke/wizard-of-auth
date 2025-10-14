using Microsoft.EntityFrameworkCore;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<AccessToken> Tokens => Set<AccessToken>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Session> Sessions => Set<Session>();
    // public DbSet<IdentityProvider> IdentityProviders => Set<IdentityProvider>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply all configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        // Global query filter to exclude soft-deleted entities
        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<Client>().HasQueryFilter(c => !c.IsDeleted);
    }
    
    // Override audit logging 
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditLog && 
                        (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

        foreach (var entry in entries)
        {
            var auditLogEntity = (AuditLog)entry.Entity;
            auditLogEntity.Timestamp = DateTime.UtcNow;
            
            switch (entry.State)
            {
                case EntityState.Added:
                    auditLogEntity.Action = "Created";
                    auditLogEntity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    auditLogEntity.Action = "Updated";
                    auditLogEntity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    auditLogEntity.Action = "Deleted";
                    auditLogEntity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}