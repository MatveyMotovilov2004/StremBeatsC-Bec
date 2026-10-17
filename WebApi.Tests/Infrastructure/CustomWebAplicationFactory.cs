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
        "http://10.0.2.15:8080");

        builder.UseSetting(
            "Jwt:Secret",
            "IntegrationTestsOnly_ChangeThisToA32ByteMinimumSecret!");

        builder.UseSetting(
            "Jwt:Issuer",
            "IdentityInfrastructureAuthentication");

        builder.UseSetting(
            "Jwt:Audience",
            "IdentityApplication");
        //Environment.SetEnvironmentVariable(
        //"Jwt__Secret",
        //"IntegrationTestsOnly_ChangeThisToA32ByteMinimumSecret!");

        //Environment.SetEnvironmentVariable(
        //    "Jwt__Issuer",
        //    "IdentityInfrastructureAuthentication");

        //Environment.SetEnvironmentVariable(
        //    "Jwt__Audience",
        //    "IdentityApplication");
    }
}
