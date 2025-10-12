using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class TokenConfiguration : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.ToTable("Tokens");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Value)
            .IsRequired()
            .HasMaxLength(2000);

        builder.HasIndex(t => t.Value)
            .IsUnique();

        builder.Property(t => t.Type)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(t => new { t.UserId, t.ClientId, t.Type });

        builder.HasIndex(t => t.ExpiresAt);

        builder.HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.Client)
            .WithMany()
            .HasForeignKey(t => t.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
