using Microsoft.EntityFrameworkCore;
using Identity.Domain;
using Identity.Infrastructure.Persistence.Configuration;

namespace Identity.Infrastructure.Persistence;

public class IdentityDbContext : DbContext
{
    public DbSet<User> User => Set<User>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
