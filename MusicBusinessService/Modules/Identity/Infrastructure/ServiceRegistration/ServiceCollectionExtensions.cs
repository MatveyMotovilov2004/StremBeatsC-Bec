using Identity.Application.Services.InfrastructureContract;
using Identity.Infrastructure.Authentication;
using Identity.Infrastructure.ValidationService;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;
using MusicBusinessService.Modules.Identity.Infrastructure.Authentication;

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

        return services;
    }
}
