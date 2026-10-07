using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Identity.Infrastructure.Persistence.Configuration;

public class SessionConfiguration
    : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UserId)
            .IsRequired();
        builder.Property(a => a.CreatedAt)
            .IsRequired();
        builder.Property(a => a.LastActivityAt)
            .IsRequired();
        builder.Property(a => a.RevokedAt)
            .IsRequired(false);
        builder.HasOne(a => a.User)
            .WithMany(b => b.Sessions)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
