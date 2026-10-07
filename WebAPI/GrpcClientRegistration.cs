using AuthenticationGrpc;
using RefreshTokenGrpc;
using Register;
using Tracks;
using UploadTrack;

namespace WebAPI.GrpcClientRegistration;

public static class GrpcClientRegistration
{
    public static IServiceCollection AddBusinessLogicGrpcClient(
        this IServiceCollection services)
    {
        const string address = "https://localhost:7298";

        services
            .AddGrpcClient<TrackGrpcService.TrackGrpcServiceClient>(
            o => o.Address = new Uri(address));
        services
            .AddGrpcClient<RegisterGrpcServise.RegisterGrpcServiseClient>(
            o => o.Address = new Uri(address));
        services
            .AddGrpcClient<RefreshTokenGrpcServise.RefreshTokenGrpcServiseClient>(
            o => o.Address = new Uri(address));
        services
            .AddGrpcClient<AuthenticationGrpcService.AuthenticationGrpcServiceClient>(
            o => o.Address = new Uri(address));
        return services;
    }

    public static IServiceCollection AddGoGrpcClients(
        this IServiceCollection services)
    {
        const string address = "https://localhost:7280";

        services
            .AddGrpcClient<UploadTrackGrpcService.UploadTrackGrpcServiceClient>(o =>
            o.Address = new Uri(address));

        return services;
    }

}
