using Identity.Domain;

namespace Identity.Application;

public interface IUserRegistrationService
{
    Task<User> RegisterUserAsync(
        string userName,
        string email,
        string passwordHash,
        CancellationToken ct);
}
