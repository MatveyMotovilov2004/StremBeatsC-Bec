using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Authentication;

namespace WebAPI
{
    public static class AuthenticationRegistration
    {
        public static IServiceCollection AddApiAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtOption = configuration
            .GetSection("Jwt")
            .Get<JwtValidationOptions>()
            ?? throw new InvalidOperationException(
                "JWT configuration is missing.");

            if(string.IsNullOrWhiteSpace(jwtOption.Secret) ||
               string.IsNullOrWhiteSpace(jwtOption.Issuer) ||
               string.IsNullOrWhiteSpace(jwtOption.Audience))
            {
                throw new InvalidOperationException(
                    "JWT configuration is incomplete.");
            }

            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOption.Secret));

            services.Configure<JwtValidationOptions>(
                configuration.GetSection("Jwt"));

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters
                        = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOption.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtOption.Audience,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromSeconds(30)
                    };  
                });

            services.AddAuthorization();

            return services;
        }
    }
}
