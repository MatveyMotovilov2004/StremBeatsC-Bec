using Npgsql;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace WebApi.Tests;

public class DatabaseSmokeTests
{
    [Fact]
    public async Task TestDatabase_IsReachable()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = config.GetConnectionString("IntegrationTestsDb");

        Assert.False(string.IsNullOrWhiteSpace(connectionString));

        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync();

        await using var command = new NpgsqlCommand("SELECT 1", connection);
        var result = await command.ExecuteScalarAsync();


        Assert.Equal(1, Convert.ToInt32(result));
    }
}
