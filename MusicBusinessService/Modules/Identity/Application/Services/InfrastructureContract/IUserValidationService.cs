namespace Identity.Application.Services.InfrastructureContract;

public interface IUserValidationService
{
    Task<bool> IsUserNameAvailableAsync(
        string userName, CancellationToken ct);

    Task<bool> IsEmailAvailableAsync(
        string email, CancellationToken ct);
}
