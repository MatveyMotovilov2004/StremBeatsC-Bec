using Identity.Application.Services.Authentication.Contract;
using Identity.Application.Services.InfrastructureContract;
using Identity.Domain;
using MediatR;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;

namespace Identity.Application.Services.Authentication.Implementation;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly IUserReader _userReader;
    private readonly IPasswordServise _passwordServise;
    public UserAuthenticationService(
        IUserReader userReader,
        IPasswordServise passwordServise)
    {
        _userReader = userReader;
        _passwordServise = passwordServise;
    }
    public async Task<User> AuthenticateAsync(
        string email, string password, CancellationToken ct)
    {
        var user = await _userReader.FindByEmailAsync(email, ct);

        if (user is null)
            throw new InvalidOperationException("Invalid credentials.");

        if (!_passwordServise.Verify(password, user.PasswordHash))
            throw new InvalidOperationException("Invalid credentials.");

        return user;
    }
}
