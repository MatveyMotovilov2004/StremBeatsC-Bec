using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using WebAPI;

namespace WebApi.Tests.Infrastructure;

public class CustomWebApplicationFactory
    :WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.UseSetting(
        "GrpcServices:MusicBusinessService",
        "http://music-business-service:8080");

        builder.UseSetting(
            "Jwt:Secret",
            "AMzpqLUpUtG8jRE+SR8n6Tz34JRVsQOLB3h34yaZWRgO/9G3SLKnSpt/VtzvuktL");

        builder.UseSetting(
            "Jwt:Issuer",
            "IdentityInfrastructureAuthentication");

        builder.UseSetting(
            "Jwt:Audience",
            "IdentityApplication");
    }
}
