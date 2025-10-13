using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants");
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.HasIndex(t => t.Name);
        
        // For domain isolation
        builder.HasIndex(t => t.Domain)
            .IsUnique();

        builder.Property(t => t.IsActive);
        builder.Property(t => t.IsDeleted);
        
        builder.Property(t => t.CreatedAt)
            .IsRequired();
        
        builder.Property(t => t.UpdatedAt);
        
        builder.Property(t => t.DeletedAt);
        
        builder.Property(t => t.Settings)
            .HasColumnType("jsonb") // PostgreSQL JSONB for efficient querying
            .IsRequired()
            .HasDefaultValue("{}");
        
        // Soft delete filter
        builder.HasQueryFilter(t => !t.IsDeleted);
        
        // NOTE: Relationships are defined in Client/User configs
        // define one-to-many relationships here if needed
    }
}