using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;
using RefreshTokenGrpc;

namespace Identity.Application;

public class RefrashTokenHandler
    : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IdentityDbContext _db;
    private readonly ITokenService _tokenService;

    public RefrashTokenHandler(
        IdentityDbContext db,
        ITokenService tokenService)
    {
        _db = db;
        _tokenService = tokenService;
    }
    public async Task<RefreshTokenResponse> Handle(
        RefreshTokenCommand request, CancellationToken ct)
    {
        //var storedRefreshToken = await FindValidRefreshTokenAsync(
        //    request.refreshToken, ct);

        //if  (storedRefreshToken is null)
        //    throw new InvalidOperationException("Refresh token not found.");
        
        //var accessToken = _tokenService.GenerateAccessToken(
        //    storedRefreshToken.User);
        //var refreshToken = _tokenService.GenerateRefreshToken();

        //storedRefreshToken.IsRevoked = true;

        //var refreshTokenEntity = new RefreshToken
        //{
        //    UserId = storedRefreshToken.UserId,
        //    Token = refreshToken,
        //    ExpiresAt = DateTime.UtcNow.AddDays(30),
        //    IsRevoked = false,
        //    CreatedAt = DateTime.UtcNow
        //};

        //_db.Add(refreshTokenEntity);
        //await _db.SaveChangesAsync(ct);

        return new RefreshTokenResponse
        {
            //AccessToken = accessToken,
            //RefreshToken = refreshToken
        };
    }

    //private async Task<RefreshToken?> FindValidRefreshTokenAsync(
    //    string refreshToken, CancellationToken ct)
    //{
    //    return await _db.refreshTokens
    //        .Include(a => a.User)
    //        .FirstOrDefaultAsync(b =>
    //            b.Token == refreshToken
    //            && !b.IsRevoked
    //            && b.ExpiresAt > DateTime.UtcNow, ct);
    //}
}
