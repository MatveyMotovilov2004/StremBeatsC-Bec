using Identity.Application.Services.InfrastructureContract;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure;

public class RoleReader : IRoleReader
{
    private readonly IdentityDbContext _db;
    public RoleReader(
        IdentityDbContext db)
    {
        _db = db;
    }
    public async Task<Role> FindByTypeAsync(
        RoleType type, CancellationToken ct)
    {
        return await _db.roles
            .SingleAsync(x => x.Type == type, ct);
    }
}
