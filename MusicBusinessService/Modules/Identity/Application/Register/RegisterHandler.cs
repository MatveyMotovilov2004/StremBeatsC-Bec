using Identity.Application;
using Identity.Application.Register;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;
using Register;


namespace MusicBusinessService.Modules.Identity.Application.Register;

public class RegisterHandler
    : IRequestHandler<RegisterCommand, RegisterUserRespounse>
{
    private readonly IdentityDbContext _db;
    private readonly ITokenService _tokenService;
    private readonly IUserRegistrationService _userRegistrationService;

    public RegisterHandler(
        IdentityDbContext db,
        ITokenService tokenService,
        IUserRegistrationService userRegistrationService)
    {
        _db = db;
        _tokenService = tokenService;
        _userRegistrationService = userRegistrationService;
    }
    public async Task<RegisterUserRespounse> Handle(
        RegisterCommand request, 
        CancellationToken ct)
    {
        var user = await _userRegistrationService.RegisterUserAsync(
            request.userName, request.email, request.passwordHash, ct);
        
        _db.Add(user);

        await _db.SaveChangesAsync(ct);

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.CreateRefreshToken();

        return new RegisterUserRespounse
        {
            UserId = user.Id,
            Email = user.Email,
            Username = user.UserName,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }
}
