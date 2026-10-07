using Identity.Application.Services.Authentication.Contract;
using Identity.Domain;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;

namespace Identity.Application.Services.Authentication.Implementation;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly ;
    private readonly IPasswordServise _passwordServise;
    public Task<User> AuthenticateAsync(
        string email, string password, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
