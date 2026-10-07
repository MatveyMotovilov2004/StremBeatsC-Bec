using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UserName)
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(a => a.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(a => a.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();
        builder.Property(a => a.DeletedAt)
            .IsRequired(false);
        builder.HasIndex(a => a.UserName)
            .IsUnique()
            .HasDatabaseName("user_username_key");
        builder.HasIndex(a => a.Email)
            .IsUnique()
            .HasDatabaseName("user_email_key");
    }
}
