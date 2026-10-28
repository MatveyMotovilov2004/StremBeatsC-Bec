using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Secrets;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Identity.Infrastructure;

public static class IdentityModule
{
    public static IServiceCollection AddIdentityModule(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            DockerSecretReader.ReadRequired("db_connection_string");

        services.AddDbContext<IdentityDbContext>(option =>
            option
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());
        // не регистрирую медиатор так как они все находятся в одном dll
        return services;
    }
}
