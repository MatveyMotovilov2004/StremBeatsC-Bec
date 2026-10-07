using Identity.Domain;

namespace Identity.Application.Services.RefreshTokens.Contract;

public interface IRefreshTokenFactory
{
    RefreshToken Create(Session session);
}
