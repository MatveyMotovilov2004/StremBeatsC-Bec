using Identity.Application.Services.InfrastructureContract;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Authentication;

public class RefreshTokenReader : IRefreshTokenReader
{
    private readonly IdentityDbContext _db;
    public RefreshTokenReader(
        IdentityDbContext db)
    {
        _db = db;
    }
    public async Task<RefreshToken?> FindByTokenAsync(
        string token, CancellationToken ct)
    {
        return await _db.refreshTokens
            .Include(a => a.Session)
            .ThenInclude(b => b.User)
            .FirstOrDefaultAsync(
                b => b.Token == token, ct);
    }
}
