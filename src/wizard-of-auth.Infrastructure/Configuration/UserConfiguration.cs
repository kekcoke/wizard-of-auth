using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        // Value object configuration for Email
        builder.OwnsOne(u => u.Email, vo =>
        {
            vo.Property(v => v.Value)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(256);

            vo.HasIndex(v => v.Value)
                .IsUnique();
        });
        
        builder.Property(u => u.FirstName)
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasMaxLength(100);

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");  // or DateTime.UtcNow
        
        builder.Property(u => u.EmailVerified)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(u => u.MfaEnabled)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(u => u.MfaMethods)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        builder.Property(u => u.LastLoginAt)
            .IsRequired(false);
        
        builder.Property(u => u.FailedLoginAttempts)
            .IsRequired()
            .HasDefaultValue(0);
        
        builder.Property(u => u.IsLocked)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(u => u.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
        
        builder.Property(u => u.DeletedAt)
            .IsRequired(false);

        builder.HasMany(u => u.Sessions)
            .WithOne()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany<RefreshToken>()
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Value object configuration for HashedPassword
        builder.OwnsOne(u => u.HashedPassword, vo =>
        {
            vo.Property(v => v.Value)
                .IsRequired()
                .HasMaxLength(256);
        });
        
        // Multi-tenancy
        builder.HasOne<Tenant>()
            .WithMany(t => t.Users)
            .HasForeignKey(u => u.TenantId);

        // Indices
        builder.HasIndex(u => new { u.TenantId, u.Email, u.IsDeleted, u.EmailVerified });
        builder.HasIndex(u => new { u.CreatedAt });
        
        // Query filter to exclude soft-deleted users
        builder.HasQueryFilter(u => !u.IsDeleted);
    }
}
