using Microsoft.AspNetCore.Mvc.Testing;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using WebApi.Tests.Infrastructure;
using WebAPI;

namespace AuthControllerIntegrationTests;

public class RegiserUserIntegrationTests 
    :IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    public RegiserUserIntegrationTests(
        CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task RegisterUser_WithValidData_ReturnsSuccess()
    {
        var request = new
        {
            username = $"test-{Guid.NewGuid():N}"[..30],
            email = $"test-{Guid.NewGuid():N}@example.com",
            password = "TestPassword123!"
        };

        var response = await _client.PostAsJsonAsync(
            "/api/Auth/register", request, TestContext.Current.CancellationToken);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content
            .ReadFromJsonAsync<RegisterResponse>(
            cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(body);
        Assert.True(body.UserId > 0);
        Assert.False(string.IsNullOrWhiteSpace(body.AccessToken));
        Assert.False(string.IsNullOrWhiteSpace(body.RefreshToken));

        await using var connection = new NpgsqlConnection(
    "Host=integration-test-postgres;Port=5432;Database=integration_test_db;Username=testuser;Password=testpassword");

        await connection.OpenAsync();

        await using var command = new NpgsqlCommand(
            """
            SELECT COUNT(*)
            FROM "user"
            WHERE "id" = @id
            AND "email" = @email
            AND "userName" = @username
            """,
            connection);

        command.Parameters.AddWithValue("id", body.UserId);
        command.Parameters.AddWithValue("email", request.email);
        command.Parameters.AddWithValue("username", request.username);

        var count = Convert.ToInt64(await command.ExecuteScalarAsync());

        Assert.Equal(1L, count);
    }
    private class RegisterResponse
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
