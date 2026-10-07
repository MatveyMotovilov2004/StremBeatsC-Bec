using Identity.Domain;

namespace Identity.Application.Services.InfrastructureContract;

public interface IRefreshTokenReader
{
    Task<RefreshToken?> FindByTokenAsync(
        string token,
        CancellationToken ct); 
}
