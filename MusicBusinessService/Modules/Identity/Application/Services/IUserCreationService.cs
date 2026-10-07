using Identity.Domain;

namespace MusicBusinessService.Modules.Identity.Application.Services;

public interface IUserCreationService
{
    Task<User> CreateUserAsync(
        string userName,
        string email,
        string passwordHash,
        CancellationToken ct);
}
