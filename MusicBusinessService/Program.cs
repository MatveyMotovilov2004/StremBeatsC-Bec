using MusicBusinessService.Modules.Catalog;
using Modules.Moderation;
using Modules.Playlist;
using Modules.Social;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MusicBusinessService.Modules.Catalog.GrpcServices;

namespace MusicBusinessService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();

        builder.Services.AddCatalogModule(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<TrackService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}
