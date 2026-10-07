using Identity.Application.Register;
using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Application.Services.RefreshTokens.Implementation;
using Identity.Application.Services.Sessions.Contract;
using Identity.Application.Services.Sessions.Implementation;
using MusicBusinessService.Modules.Identity.Application.Services;

namespace Identity.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserCreationService, UserCreationService>();
        services.AddScoped<ISessionFactory, SessionFactory>();
        services.AddScoped<IRefreshTokenFactory, RefreshTokenFactory>();

        return services;
    }
}
