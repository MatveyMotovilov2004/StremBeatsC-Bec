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

        var secretConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                "secret.json",
                optional: false,
                reloadOnChange: false)
            .Build();

        var secret = secretConfiguration["Jwt:Secret"];

        if (string.IsNullOrWhiteSpace(secret))
        {
            throw new InvalidOperationException(
                "JWT secret is missing.");
        }

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
