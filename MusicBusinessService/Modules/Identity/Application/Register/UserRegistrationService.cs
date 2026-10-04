using Identity.Application;
using Identity.Domain;

namespace Identity.Application.Register;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly IUserValidationService _userValidationService;

    public UserRegistrationService(IUserValidationService userValidationService)
    {
        _userValidationService = userValidationService;
    }
    public async Task<User> RegisterUserAsync(
        string userName, 
        string email, 
        string passwordHash, 
        CancellationToken ct)
    {
        if (!await _userValidationService.IsEmailAvailableAsync(
            email, ct))
        {
            throw new InvalidOperationException(
            "User with this email already exists.");
        }

        if (!await _userValidationService.IsUserNameAvailableAsync(
            userName, ct))
        {
            throw new InvalidOperationException(
            "User with this username already exists.");
        }
        return new User(
            userName,
            email,
            passwordHash);
    }
}
