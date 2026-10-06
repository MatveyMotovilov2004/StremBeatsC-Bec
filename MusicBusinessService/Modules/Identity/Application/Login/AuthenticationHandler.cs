using AuthenticationGrpc;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RefreshTokenGrpc;
using System.Reflection.Metadata;

namespace Identity.Application.Login;

public class AuthenticationHandler
{
    private readonly IdentityDbContext _db;
    private readonly ITokenService _tokenService;
    private readonly IPasswordServise _passwordServise;
    public AuthenticationHandler(
        IdentityDbContext db,
        ITokenService tokenService,
        IPasswordServise passwordServise)
    {
        _db = db;
        _tokenService = tokenService;
        _passwordServise = passwordServise;
    }
    public async Task<AuthenticationResponse> Handle(
        AuthenticationRequest request, CancellationToken ct)
    {
        var user = await SearchUserByEmail(request.Email, ct);

        if (user is null)
            throw new InvalidOperationException("Invalid credentials.");

        var isPasswordValid = _passwordServise.Verify(
            request.Password, user.PasswordHash);

        if (!isPasswordValid)
            throw new InvalidOperationException("Invalid credentials.");

        

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken
        {
            UserId = user.Id,
            Token = refreshToken,
            ExpiresAt = DateTime.UtcNow.AddDays(30),
            IsRevoked = false,
            CreatedAt = DateTime.UtcNow
        };

        _db.Add(refreshTokenEntity);
        await _db.SaveChangesAsync(ct);

        return new AuthenticationResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
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
