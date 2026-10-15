
using Microsoft.AspNetCore.Mvc.Testing;
using WebApi.Tests.Infrastructure;
using WebAPI;

namespace WebApi.Tests
{
    public class WebApiSmokeTests 
        : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        public WebApiSmokeTests(
            CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetRoot_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/health");

            response.EnsureSuccessStatusCode();
        }
    }
}
