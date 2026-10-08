using Identity.Domain;
using Identity.Application.Services.InfrastructureContract;
using Identity.Application.Services.Users.Contract;

namespace Identity.Application.Services.Users.Implementation;

public class UserCreationService : IUserCreationService
{
    private readonly IUserValidationService _userValidationService;
    private readonly IPasswordServise _passwordServise;
    private readonly IRoleReader _roleReader;

    public UserCreationService(
        IUserValidationService userValidationService,
        IPasswordServise passwordServise,
        IRoleReader roleReader)
    {
        _userValidationService = userValidationService;
        _passwordServise = passwordServise;
        _roleReader = roleReader;
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
        var role = await _roleReader.FindByTypeAsync(RoleType.User, ct);
        
        var passwordHash = _passwordServise.Hash(password);

        var user = new User(userName, email, passwordHash);

        user.Roles.Add(role);

        return user;

    }
}
