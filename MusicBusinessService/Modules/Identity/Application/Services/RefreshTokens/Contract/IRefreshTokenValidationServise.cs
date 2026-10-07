using Identity.Domain;

namespace Identity.Application.Services.RefreshTokens.Contract;

public interface IRefreshTokenValidationServise
{
    Task<RefreshToken> ValidateTokenAsync(
        string token,
        CancellationToken ct);
}
