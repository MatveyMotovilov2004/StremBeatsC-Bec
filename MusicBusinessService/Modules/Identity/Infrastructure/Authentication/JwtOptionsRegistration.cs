using Identity.Infrastructure.Secrets;
using Microsoft.Extensions.Configuration.Json;

namespace Identity.Infrastructure.Authentication;

public static class JwtOptionsRegistration
{
    public static IServiceCollection AddJwtOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtOptions = configuration
            .GetSection("Jwt")
            .Get<JwtOptions>()
            ?? throw new InvalidOperationException(
                "JWT configuration is missing.");

        var secret = DockerSecretReader.ReadRequired("jwt_secret");

        jwtOptions.Secret = secret;

        if (string.IsNullOrWhiteSpace(jwtOptions.Issuer) ||
            string.IsNullOrWhiteSpace(jwtOptions.Audience) ||
            jwtOptions.ExpirstionMinutes <= 0)
        {
            throw new InvalidOperationException(
                "JWT configuration is incomplete.");
        }

        services.AddSingleton(jwtOptions);

        return services;
    }
}
