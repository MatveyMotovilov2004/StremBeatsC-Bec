using Identity.Domain;

namespace Identity.Application.Services.Users.Contract;

public interface IUserCreationService
{
    Task<User> CreateUserAsync(
        string userName,
        string email,
        string passwordHash,
        CancellationToken ct);
}
