using Microsoft.EntityFrameworkCore;
using Catalog.Domain;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Persistence;

public class CatalogDbContext : DbContext
{
    public DbSet<Track> Track => Set<Track>();

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TrackConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

