using System.Runtime.CompilerServices;
using WebAPI.Orchestrator;

namespace WebAPI
{
    public static class OrchestratorRegistration
    {
        public static IServiceCollection AddOrchestrator(
            this IServiceCollection services)
        {
            services.AddScoped<ArtistRegistrationOrchestrator>();
            return services;
        }
    }
}
