using Catalog.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;

namespace MusicBusinessService.Modules.Catalog;
public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(
        this IServiceCollection services,IConfiguration configuration)
    {
        // было GetConnectionString("CatalogDbContext")
        services.AddDbContext<CatalogDbContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(
                typeof(ICatalogHandler).Assembly);
        });
        
        return services;
    }
}
    

