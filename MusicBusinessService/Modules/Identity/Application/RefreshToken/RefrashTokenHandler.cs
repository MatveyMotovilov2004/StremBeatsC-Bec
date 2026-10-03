using Identity.Infrastructure.Persistence;
using MediatR;
using RefreshTokenGrpc;

namespace Identity.Application.RefreshToken;

public class RefrashTokenHandler
    : IRequestHandler<RefreshTokenCommand, RefreshTokenRespounse>
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
    public Task Handle(
        RefreshTokenCommand request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    // delete
    Task<RefreshTokenRespounse> IRequestHandler<RefreshTokenCommand, RefreshTokenRespounse>.Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
