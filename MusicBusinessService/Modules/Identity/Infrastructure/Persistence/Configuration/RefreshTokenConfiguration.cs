using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configuration;

public class RefreshTokenConfiguration
    :  IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.SessionId)
            .IsRequired();
        builder.Property(a => a.Token)
            .IsRequired();
        builder.Property(a => a.ExpiresAt)
            .IsRequired();
        builder.Property(a => a.IsRevoked)
            .IsRequired();
        builder.Property(a => a.CreatedAt)
            .IsRequired();
        builder.HasOne(a => a.Session )
            .WithMany(b => b.RefreshTokens)
            .HasForeignKey(c => c.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
