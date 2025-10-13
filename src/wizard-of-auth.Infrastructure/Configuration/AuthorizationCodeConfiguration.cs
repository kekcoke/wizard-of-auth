using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class AuthorizationCodeConfiguration : IEntityTypeConfiguration<AuthorizationCode>
{
    public void Configure(EntityTypeBuilder<AuthorizationCode> builder)
    {
        builder.ToTable("AuthorizationCodes");
        builder.HasKey(x => x.Id);

        builder.Property(ac => ac.Code)
            .HasMaxLength(256);
        
        builder.HasIndex(ac => ac.Code)
            .IsUnique();

        builder.Property(ac => ac.CreatedAt)
            .IsRequired();

        builder.Property(ac => ac.ExpiresAt)
            .IsRequired();

        builder.Property(ac => ac.IsUsed)
            .IsRequired()
            .HasDefaultValue(false);
        
        // PKCE support
        builder.Property(ac => ac.CodeChallenge)
            .HasMaxLength(16);

        builder.Property(ac => ac.CodeChallengeMethod)
            .HasMaxLength(10);
        
        // Indices
        builder.HasIndex(ac => ac.ExpiresAt);

        // Client & User relationships
        builder.HasOne<Client>()
            .WithMany()
            .HasForeignKey(ac => ac.ClientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(ac => ac.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}