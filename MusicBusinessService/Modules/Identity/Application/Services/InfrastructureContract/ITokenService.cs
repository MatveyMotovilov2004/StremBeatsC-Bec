using Identity.Domain;

namespace Identity.Application.Services.InfrastructureContract;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
