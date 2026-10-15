namespace Identity.Application.Services.InfrastructureContract;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
