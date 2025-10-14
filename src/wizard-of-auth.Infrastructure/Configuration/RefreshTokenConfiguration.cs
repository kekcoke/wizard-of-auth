using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

/// <summary>
/// EF Core configuration for the RefreshToken entity.
/// Implements TPC (Table-Per-Concrete-Type) by mapping to a dedicated table.
/// </summary>
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // TPC Mapping: Maps the concrete type to its own table
            builder.ToTable("RefreshTokens"); 

            // Primary Key (inherited from TokenBase)
            builder.HasKey(t => t.Id);

            // --- Common/Base Configurations (Same as AccessToken) ---
            builder.Property(t => t.Scopes)
                .HasConversion(TokenConfigurationHelpers.ScopesConverter)
                .HasColumnType("nvarchar(2048)"); 

            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Client)
                .WithMany()
                .HasForeignKey(t => t.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // --- RefreshToken Specific Configurations ---

            builder.Property(t => t.TokenHash)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(t => t.FamilyId)
                .HasMaxLength(64)
                .IsUnicode(false); // Optional token family ID

            builder.Property(t => t.ReplacedByTokenHash)
                .HasMaxLength(256); // For token rotation tracking

            // Store enum as string for readability in the database
            builder.Property(t => t.RevocationReason)
                .HasConversion<string>() 
                .HasMaxLength(32); 
            
            builder.Property(t => t.DeviceId)
                .HasMaxLength(256);
                
            builder.Property(t => t.IpAddress)
                .HasMaxLength(45) // Accommodates IPv6
                .IsUnicode(false);

            // Indexing for performance
            builder.HasIndex(t => t.TokenHash).IsUnique();
            builder.HasIndex(t => t.FamilyId);
            builder.HasIndex(t => t.UserId);
            builder.HasIndex(t => t.ClientId);
            builder.HasIndex(t => t.UsedAt);
            builder.HasIndex(t => t.ExpiresAt);

            // Ignore computed properties/methods
            builder.Ignore(t => t.IsExpired);
            builder.Ignore(t => t.IsUsed); // Computed property on UsedAt
        }
}