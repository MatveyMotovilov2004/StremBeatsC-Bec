namespace Identity.Application;

public interface IUserValidationService
{
    Task<bool> IsUserNameAvailableAsync(
        string userName, CancellationToken ct);

    Task<bool> IsEmailAvailableAsync(
        string email, CancellationToken ct);
}
