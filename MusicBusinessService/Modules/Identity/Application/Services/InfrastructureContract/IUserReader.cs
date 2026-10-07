using Identity.Domain;

namespace Identity.Application.Services.InfrastructureContract;

public interface IUserReader
{
    Task<User?> FindByEmailAsync(
        string email,
        CancellationToken ct);
}
