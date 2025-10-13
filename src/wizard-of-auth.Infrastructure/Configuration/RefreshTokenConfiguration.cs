using Microsoft.EntityFrameworkCore;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(rt => rt.Id);

        // Owned value object (in Core) configuration
        builder.OwnsOne(rt => rt.Token, vo =>
        {
            vo.Property(v => v.Value)
                .IsRequired()
                .HasColumnName("Token")
                .HasMaxLength(2000);

            vo.HasIndex(v => v.Value)
                .IsUnique();

            vo.Property(v => v.ExpiresAt)
                .IsRequired()
                .HasColumnName("ExpiresAt");
        });

        builder.Property(rt => rt.CreatedAt)
            .IsRequired();

        builder.Property(rt => rt.IsUsed)
            .IsRequired();

        builder.Property(rt => rt.IsRevoked)
            .IsRequired();

        builder.Property(rt => rt.RevokedAt);
        
        builder.Property(rt => rt.ReplacedByToken)
            .HasMaxLength(2000);
        
        // Relationships
        builder.HasOne(rt => rt.User)
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rt => rt.Client)
            .WithMany()
            .HasForeignKey(rt => rt.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Indexes
        builder.HasIndex(rt => new { rt.UserId, rt.ClientId });
        builder.HasIndex(rt => rt.CreatedAt);
        builder.HasIndex(rt => rt.ExpiresAt);
        builder.HasIndex(rt => rt.IsUsed);
        builder.HasIndex(rt => rt.IsRevoked);
    }
}