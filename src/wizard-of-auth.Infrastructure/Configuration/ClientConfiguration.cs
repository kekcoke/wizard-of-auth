using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(c => c.Id);
        
        builder.HasIndex(c => c.Id)
            .IsUnique();
        
        builder.HasOne<Tenant>()
            .WithMany(t => t.Clients)
            .HasForeignKey(c => c.TenantId);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(c => c.Description)
            .HasMaxLength(1000);
        
        builder.Property(c => c.AllowedScopes)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        builder.Property(c => c.AllowedGrantTypes)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        builder.Property(c => c.RedirectUris)
            .HasConversion(
                v => string.Join('|', v),
                v => v.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

        builder.Property(c => c.AccessTokenLifetime)
            .IsRequired()
            .HasDefaultValue(3600);

        builder.Property(c => c.RequirePkce)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(c => c.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);
                
        builder.Property(c => c.ClientSecret)
            .HasMaxLength(256);

        // Index
        builder.HasIndex(c => new { c.TenantId, c.Id });
        
        // Query filter
        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}
