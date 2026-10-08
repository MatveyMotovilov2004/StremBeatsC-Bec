using Microsoft.EntityFrameworkCore;
using Identity.Domain;
using Identity.Infrastructure.Persistence.Configuration;

namespace Identity.Infrastructure.Persistence;

public class IdentityDbContext : DbContext
{
    public DbSet<User> user => Set<User>();
    public DbSet<RefreshToken> refreshTokens => Set<RefreshToken>();
    public DbSet<Session> sessions => Set<Session>();
    public DbSet<Role> roles => Set<Role>();

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
