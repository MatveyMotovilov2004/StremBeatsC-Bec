using Identity.Application.Services.InfrastructureContract;
using Identity.Infrastructure.Persistence;
using LogoutGrpc;
using MediatR;

namespace Identity.Application.Logout;

public class LogoutHandler
    : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly IdentityDbContext _db;
    private readonly IRefreshTokenReader _refreshTokenReader;
    public LogoutHandler(
        IdentityDbContext db,
        IRefreshTokenReader refreshTokenReader)
    {
        _db = db;
        _refreshTokenReader = refreshTokenReader;
    }
    public async Task<LogoutResponse> Handle(
        LogoutCommand request, CancellationToken ct)
    {
        var storedRefreshToken =
            await _refreshTokenReader.FindByTokenAsync(
                request.refreshToken, ct);

        if(storedRefreshToken is null)
            throw new InvalidOperationException("Invalid refresh token.");

        storedRefreshToken.Session.RevokedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync(ct);

        return new LogoutResponse();
    }
}
