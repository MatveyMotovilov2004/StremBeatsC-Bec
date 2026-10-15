using Identity.Application.Services.InfrastructureContract;
using Identity.Infrastructure.Persistence;

namespace Identity.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly IdentityDbContext _db;
    public UnitOfWork(
        IdentityDbContext db)
    {
        _db = db;
    }
    public async Task<int> SaveChangesAsync(
        CancellationToken ct = default)
    {
        return await _db.SaveChangesAsync(ct);
    }
}
