using Identity.Domain;

namespace Identity.Application.Services.InfrastructureContract;

public interface IRoleReader
{
    Task<Role> FindByTypeAsync(
        RoleType type,
        CancellationToken ct);
}
