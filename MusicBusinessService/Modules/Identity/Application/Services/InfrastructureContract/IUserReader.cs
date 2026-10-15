using Identity.Domain;

namespace Identity.Application.Services.InfrastructureContract;

public interface IUserReader
{
    Task<User?> FindByEmailAsync(
        string email,
        CancellationToken ct);

    Task<User?> FindByIdAsync(
        int Id,
        CancellationToken ct);
}
