using Identity.Application.Services.InfrastructureContract;
using Identity.Infrastructure.Persistence;

namespace Identity.Infrastructure;

public class DbContextStateAdder : IDbContextStateAdder
{
    private readonly IdentityDbContext _db;
    public DbContextStateAdder(
        IdentityDbContext db)
    {
        _db = db;
    }

    public Task AddRangeAsync(CancellationToken ct, params object[] dbRecords)
    {
        if (dbRecords is null || dbRecords.Length == 0)
            return Task.CompletedTask;

        //Метод AddRange принимает массив object[]
        // и сам определяет, к какому DbSet относится каждый объект
        _db.AddRange(dbRecords);

        return Task.CompletedTask;
    }
}
