using Identity.Application.Services.InfrastructureContract;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Authentication;

public class UserReader : IUserReader
{
    private readonly IdentityDbContext _db;
    public UserReader(
        IdentityDbContext db)
    {
        _db = db;
    }
    public async Task<User?> FindByEmailAsync(
        string email, CancellationToken ct)
    {
        return await _db.user
        .FirstOrDefaultAsync(
        x => x.Email == email, ct);
    }
}
