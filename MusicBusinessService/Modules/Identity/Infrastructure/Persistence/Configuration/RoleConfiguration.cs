using Identity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configuration;

public class RoleConfiguration 
    : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Type)
            .IsRequired();
        builder.HasIndex(a => a.Type)
            .IsUnique();
        builder.HasData(
            new Role { Id = 1, Type = RoleType.User },
            new Role { Id = 2, Type = RoleType.Artist });
    }
}
