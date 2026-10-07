using Identity.Domain;

namespace MusicBusinessService.Modules.Identity.Application.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
