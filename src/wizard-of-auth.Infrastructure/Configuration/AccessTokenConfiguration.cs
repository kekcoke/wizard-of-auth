using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class AccessTokenConfiguration : IEntityTypeConfiguration<AccessToken>
{
    public void Configure(EntityTypeBuilder<AccessToken> builder)
    {
        // TPC Mapping: Maps the concrete type to its own table
        builder.ToTable("AccessTokens"); 

        // Primary Key (inherited from TokenBase)
        builder.HasKey(t => t.Id);
            
        // --- Common/Base Configurations ---

        // Scopes Conversion: Stores IReadOnlyList<string> as a delimited string
        builder.Property(t => t.Scopes)
            .HasConversion(TokenConfigurationHelpers.ScopesConverter)
            .HasColumnType("nvarchar(2048)"); 

        // Foreign Keys
        builder.HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // If user is deleted, tokens should be deleted.

        builder.HasOne(t => t.Client)
            .WithMany()
            .HasForeignKey(t => t.ClientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // Prevent accidental client deletion if tokens exist.

        // --- AccessToken Specific Configurations ---

        builder.Property(t => t.TokenHash)
            .IsRequired()
            .HasMaxLength(256); // A typical size for SHA256 hash in Base64 encoding

        builder.Property(t => t.Jti)
            .HasMaxLength(128)
            .IsUnicode(false);

        // Indexing for performance
        builder.HasIndex(t => t.TokenHash).IsUnique();
        builder.HasIndex(t => t.UserId);
        builder.HasIndex(t => t.ClientId);
        builder.HasIndex(t => t.ExpiresAt);
            
        // Ignore computed properties/methods
        builder.Ignore(t => t.IsExpired);
    }
}
