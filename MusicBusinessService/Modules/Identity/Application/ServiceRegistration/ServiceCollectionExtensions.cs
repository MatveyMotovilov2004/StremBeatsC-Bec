using Identity.Application.Services.Authentication.Contract;
using Identity.Application.Services.Authentication.Implementation;
using Identity.Application.Services.RefreshTokens.Contract;
using Identity.Application.Services.RefreshTokens.Implementation;
using Identity.Application.Services.Sessions.Contract;
using Identity.Application.Services.Sessions.Implementation;
using Identity.Application.Services.Users.Implementation;
using Identity.Application.Services.Users.Contract;

namespace Identity.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentityApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IUserCreationService, UserCreationService>();
        services.AddScoped<ISessionFactory, SessionFactory>();
        services.AddScoped<IRefreshTokenFactory, RefreshTokenFactory>();
        services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        services.AddScoped<IRefreshTokenValidationServise, RefreshTokenValidationService>();

        return services;
    }
}
