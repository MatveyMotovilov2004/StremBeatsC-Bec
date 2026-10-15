using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using WebAPI;

namespace WebApi.Tests.Infrastructure;

public class CustomWebApplicationFactory
    :WebApplicationFactory<Program>
{
}
