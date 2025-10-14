using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wizard_of_auth.Core.Entities;

namespace wizard_of_auth.Infrastructure.Configuration;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SessionToken)
            .IsRequired();
        // no max length, as it can be a long JWT or opaque token
        builder.HasIndex(s => s.SessionToken)
            .IsUnique();

        builder.Property(s => s.CreatedAt)
            .IsRequired();
        
        builder.Property(s => s.ExpiresAt)
            .IsRequired();

        builder.Property(s => s.LastActivityAt);
        
        builder.Property(s => s.IpAddress)
            .HasMaxLength(45); // IPv6

        builder.Property(s => s.UserAgent)
            .HasMaxLength(500);

        builder.Property(s => s.AuthenticationMethod)
            .IsRequired();
        
        // Indices
        builder.HasIndex(s => s.ExpiresAt);
        builder.HasIndex(s => new { s.UserId, s.CreatedAt });
        
        // NOTE: Relationship defined in UserConfirguration
    }
}