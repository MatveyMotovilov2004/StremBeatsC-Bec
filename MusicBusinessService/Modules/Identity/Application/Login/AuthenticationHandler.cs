using AuthenticationGrpc;
using Identity.Application.Services.Authentication.Contract;
using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Application.Services.Sessions.Contract;
using Identity.Infrastructure.Persistence;
using MediatR;
using Identity.Application.Services.InfrastructureContract;

namespace Identity.Application.Login;

public class AuthenticationHandler
    : IRequestHandler<AuthenticationCommand, AuthenticationResponse>
{
    private readonly IdentityDbContext _db;
    private readonly ITokenService _tokenService;
    private readonly IUserAuthenticationService _userAuthenticationService;
    private readonly ISessionFactory _sessionFactory;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    public AuthenticationHandler(
        IdentityDbContext db,
        ITokenService tokenService,
        IUserAuthenticationService userAuthenticationService,
        ISessionFactory sessionFactory,
        IRefreshTokenFactory refreshTokenFactory)
    {
        _db = db;
        _tokenService = tokenService;
        _userAuthenticationService = userAuthenticationService;
        _sessionFactory = sessionFactory;
        _refreshTokenFactory = refreshTokenFactory;
    }
    public async Task<AuthenticationResponse> Handle(
        AuthenticationCommand request, CancellationToken ct)
    {
        var user = await _userAuthenticationService.AuthenticateAsync(
            request.email, request.password, ct);

        var accessToken = _tokenService.GenerateAccessToken(user);
        var session = _sessionFactory.Create(user);
        var refreshToken = _refreshTokenFactory.Create(session);

        _db.Add(session);
        _db.Add(refreshToken);
 
        await _db.SaveChangesAsync(ct);

        return new AuthenticationResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }
}
