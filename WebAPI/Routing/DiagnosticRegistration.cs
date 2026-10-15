using Google.Protobuf.WellKnownTypes;

namespace WebAPI.Diagnostics;

public static class DiagnosticRegistration
{
    public static WebApplication MapDiagnosticEndpoints(
        this WebApplication app)
    {
        app.MapControllers();

        app.MapGet("/health", () =>
            Results.Ok(new
            {
                Status = "Healthy",
                Timestamp = DateTime.UtcNow
            }))
            .AllowAnonymous();

        return app;
    }
}
