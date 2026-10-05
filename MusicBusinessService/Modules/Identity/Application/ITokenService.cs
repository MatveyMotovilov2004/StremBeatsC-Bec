using Identity.Domain;

namespace Identity.Application;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
