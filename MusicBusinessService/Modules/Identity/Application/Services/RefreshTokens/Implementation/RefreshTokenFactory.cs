using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Domain;
using Identity.Application.Services.InfrastructureContract;

namespace Identity.Application.Services.RefreshTokens.Implementation;

public class RefreshTokenFactory : IRefreshTokenFactory
{
    private readonly ITokenService _tokenService;

    public RefreshTokenFactory(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }
    public RefreshToken Create(Session session)
    {
        var now = DateTime.UtcNow;

        return new RefreshToken
        {
            Session = session,
            Token = _tokenService.GenerateRefreshToken(),
            ExpiresAt = now.AddDays(30),
            IsRevoked = false,
            CreatedAt = now
        };
    }
}
