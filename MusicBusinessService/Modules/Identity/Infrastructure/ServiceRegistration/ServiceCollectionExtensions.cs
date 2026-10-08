using Identity.Application.Services.InfrastructureContract;
using Identity.Infrastructure.Authentication;
using Identity.Infrastructure.ValidationService;

namespace Identity.Infrastructure.ServiceRegistration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserValidationService, UserValidationService>();
        services.AddScoped<IPasswordServise, PasswordService>();
        services.AddScoped<IUserReader, UserReader>();
        services.AddScoped<IRefreshTokenReader, RefreshTokenReader>();
        services.AddScoped<IRoleReader, RoleReader>();

        return services;
    }
}
