using Identity.Domain;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;

namespace Identity.Application.Register;

public class UserCreationService : IUserCreationService
{
    private readonly IUserValidationService _userValidationService;
    private readonly IPasswordServise _passwordServise;

    public UserCreationService(
        IUserValidationService userValidationService,
        IPasswordServise passwordServise)
    {
        _userValidationService = userValidationService;
        _passwordServise = passwordServise;
    }
    public async Task<User> CreateUserAsync(
        string userName, 
        string email, 
        string password, 
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

        var passwordHash = _passwordServise.Hash(password);

        return new User(
            userName,
            email,
            passwordHash);
    }
}
