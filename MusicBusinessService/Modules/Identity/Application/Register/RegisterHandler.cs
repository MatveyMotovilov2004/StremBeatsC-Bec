using Identity.Application.Register;
using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Application.Services.Sessions.Contract;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;
using Identity.Application.Services.InfrastructureContract;
using Register;
using Identity.Application.Services.Users.Contract;


namespace MusicBusinessService.Modules.Identity.Application.Register;

public class RegisterHandler
    : IRequestHandler<RegisterCommand, RegisterUserRespounse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IUserCreationService _userCreationService;
    private readonly ISessionFactory _sessionFactory;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    private readonly IDbContextStateAdder _dbContextStateAdder;
    public RegisterHandler(
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        IUserCreationService userRegistrationService,
        ISessionFactory sessionFactory,
        IRefreshTokenFactory refreshTokenFactory,
        IDbContextStateAdder dbContextStateAdder)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _userCreationService = userRegistrationService;
        _sessionFactory = sessionFactory;
        _refreshTokenFactory = refreshTokenFactory;
        _dbContextStateAdder = dbContextStateAdder;
    }
    public async Task<RegisterUserRespounse> Handle(
        RegisterCommand request, CancellationToken ct)
    {
        var user = await _userCreationService.CreateUserAsync(
            request.userName, request.email, request.password, ct);
        var session = _sessionFactory.Create(user);
        var refreshToken = _refreshTokenFactory.Create(session);
        var accessToken = _tokenService.GenerateAccessToken(user);

        await _dbContextStateAdder.AddRangeAsync(ct, user, session, refreshToken);
        await _unitOfWork.SaveChangesAsync(ct);
        
        return new RegisterUserRespounse
        {
            UserId = user.Id,
            Email = user.Email,
            Username = user.UserName,
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }
}
