using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Identity.Infrastructure;

public static class IdentityModule
{
    public static IServiceCollection AddIdentityModule(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' is missing.");

        services.AddDbContext<IdentityDbContext>(option =>
            option
            .UseNpgsql(configuration.GetConnectionString(connectionString))
            .UseSnakeCaseNamingConvention());
        // не регистрирую медиатор так как они все находятся в одном dll
        return services;
    }
}
