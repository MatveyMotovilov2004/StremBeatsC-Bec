using Identity.Domain;

namespace Identity.Application.Services.Authentication.Contract;

public interface IUserAuthenticationService
{
    Task<User> AuthenticateAsync(
        string email,
        string password,
        CancellationToken ct);
}
