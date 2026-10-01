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
        services.AddDbContext<CatalogDbContext>(option =>
            option.UseNpgsql(configuration.GetConnectionString("CatalogDbContext"))
            .UseSnakeCaseNamingConvention());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(
                typeof(ICatalogHandler).Assembly);
        });
        //var catalogHandlers = typeof(ICatalogHandler)
        //.Assembly
        //.GetTypes()
        //.Where(type =>
        //    type.IsClass &&
        //    !type.IsAbstract &&
        //    typeof(ICatalogHandler).IsAssignableFrom(type));

        //foreach (var handler in catalogHandlers)
        //{
        //    var mediatRInterfaces = handler
        //        .GetInterfaces()
        //        .Where(i =>
        //            i.IsGenericType &&
        //            (
        //                i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
        //                i.GetGenericTypeDefinition() == typeof(IRequestHandler<>)
        //            ));

        //    foreach (var mediatRInterface in mediatRInterfaces)
        //    {
        //        services.AddScoped(mediatRInterface, handler);
        //    }
        //}

        //services.AddScoped<IMediator, Mediator>();

        //services.Scan(scan => scan
        //    .FromAssemblyOf<ICatalogHandler>()
        //    .AddClasses(c => c.AssignableTo<ICatalogHandler>())
        //    .AsImplementedInterfaces()
        //    .WithScopedLifetime());

        return services;
    }
        
}
    

