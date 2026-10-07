using AuthenticationGrpc;
using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Application.Services.Sessions.Contract;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;

namespace Identity.Application.Login;

public class AuthenticationHandler
    : IRequestHandler<AuthenticationCommand, AuthenticationResponse>
{
    private readonly IdentityDbContext _db;
    private readonly ITokenService _tokenService;
    private readonly IPasswordServise _passwordServise;
    private readonly ISessionFactory _sessionFactory;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    public AuthenticationHandler(
        IdentityDbContext db,
        ITokenService tokenService,
        IPasswordServise passwordServise,
        ISessionFactory sessionFactory,
        IRefreshTokenFactory refreshTokenFactory)
    {
        _db = db;
        _tokenService = tokenService;
        _passwordServise = passwordServise;
        _sessionFactory = sessionFactory;
        _refreshTokenFactory = refreshTokenFactory;
    }
    public async Task<AuthenticationResponse> Handle(
        AuthenticationCommand request, CancellationToken ct)
    {
        var user = await SearchUserByEmail(request.email, ct);

        if (user is null)
            throw new InvalidOperationException("Invalid credentials.");

        var isPasswordValid = _passwordServise.Verify(
            request.password, user.PasswordHash);

        if (!isPasswordValid)
            throw new InvalidOperationException("Invalid credentials.");

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

    private async Task<User?> SearchUserByEmail(
        string email, CancellationToken ct)
    {
        return await _db.user
            .FirstOrDefaultAsync(
            x => x.Email == email, ct);
    }
}
