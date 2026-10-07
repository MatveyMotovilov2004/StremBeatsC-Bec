using Identity.Application.Services.InfrastructureContract;
using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Domain;

namespace Identity.Application.Services.RefreshTokens.Implementation;

public class RefreshTokenValidationService
    : IRefreshTokenValidationServise
{
    private readonly IRefreshTokenReader _refreshTokenReader;
    public RefreshTokenValidationService(
        IRefreshTokenReader refreshTokenReader)
    {
        _refreshTokenReader = refreshTokenReader;
    }
    public async Task<RefreshToken> ValidateTokenAsync(
        string token, CancellationToken ct)
    {
        var refreshToken = await _refreshTokenReader.FindByTokenAsync(
            token, ct);

        if (refreshToken is null)
            throw new InvalidOperationException(
                "Invalid refresh token.");

        if (refreshToken.IsRevoked)
            throw new InvalidOperationException(
                "Invalid refresh token.");

        if (refreshToken.ExpiresAt <= DateTime.UtcNow)
            throw new InvalidOperationException(
                "Invalid refresh token.");

        if (refreshToken.Session.RevokedAt is not null)
            throw new InvalidOperationException(
                "Invalid refresh token.");

        return refreshToken;
    }
}
