using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Infrastructure.Persistence;
using MediatR;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;
using RefreshTokenGrpc;

namespace Identity.Application;

public class RefrashTokenHandler
    : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IdentityDbContext _db;
    private readonly ITokenService _tokenService;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    private readonly IRefreshTokenValidationServise _refreshTokenValidationServise;
    public RefrashTokenHandler(
        IdentityDbContext db,
        ITokenService tokenService,
        IRefreshTokenFactory refreshTokenFactory,
        IRefreshTokenValidationServise refreshTokenValidationServise)
    {
        _db = db;
        _tokenService = tokenService;
        _refreshTokenFactory = refreshTokenFactory;
        _refreshTokenValidationServise = refreshTokenValidationServise;
    }
    public async Task<RefreshTokenResponse> Handle(
        RefreshTokenCommand request, CancellationToken ct)
    {
        var storedRefreshToken =
            await _refreshTokenValidationServise.ValidateTokenAsync(
                request.refreshToken, ct);

        storedRefreshToken.IsRevoked = true;

        var refreshToken = _refreshTokenFactory.Create(
            storedRefreshToken.Session);
        var accessToken = _tokenService.GenerateAccessToken(
            storedRefreshToken.Session.User);

        _db.Add(refreshToken);
        await _db.SaveChangesAsync(ct);

        return new RefreshTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }
}
