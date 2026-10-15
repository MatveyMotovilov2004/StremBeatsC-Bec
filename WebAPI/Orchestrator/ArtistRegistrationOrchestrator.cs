using Google.Protobuf;
using ArtistGrpc;
using GiveRoleGrpc;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Orchestrator;

public class ArtistRegistrationOrchestrator
{
    private readonly ArtistGrpcService.ArtistGrpcServiceClient _mbsArtisServiceClient;
    private readonly GiveRoleGrpcService.GiveRoleGrpcServiceClient _mbsGiveRoleServiceClient;
    public ArtistRegistrationOrchestrator(
        ArtistGrpcService.ArtistGrpcServiceClient artistServiceClient,
        GiveRoleGrpcService.GiveRoleGrpcServiceClient giveRoleServiceClient)
    {
        _mbsArtisServiceClient = artistServiceClient;
        _mbsGiveRoleServiceClient = giveRoleServiceClient;
    }
    public async Task<int> CreateArtistAsync(
        CreateArtistRequestDto request,
        CancellationToken token)
    {
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        var responseIdentity = await _mbsGiveRoleServiceClient.GiveRoleArtistAsync(
            GiveRoleArtistGrpcRequest(request));
        var responseArtist = await _mbsArtisServiceClient.CreateArtistAsync(
            CreateArtistGrpcRequest(request));
        return responseArtist.ArtistId;
    }

    private CreateArtistRequest CreateArtistGrpcRequest(
        CreateArtistRequestDto request)
    {
        return new CreateArtistRequest
        {
            UserId = request.UserId,
            StageName = request.StageName
        };
    }

    private GiveRoleArtistRequest GiveRoleArtistGrpcRequest(
        CreateArtistRequestDto request)
    {
        return new GiveRoleArtistRequest
        {
            UserId = request.UserId
        };
    }
}
