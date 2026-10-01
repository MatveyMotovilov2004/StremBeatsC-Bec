using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Tracks;
using UploadTrack;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TracksController : ControllerBase
{
    private readonly TrackGrpcService.TrackGrpcServiceClient _mbsTrackClient;
    private readonly UploadTrackGrpcService.UploadTrackGrpcServiceClient _goUploadTrackClient;
    public TracksController(
        TrackGrpcService.TrackGrpcServiceClient mbsTrackClient,
        UploadTrackGrpcService.UploadTrackGrpcServiceClient goUploadTrackClient)
    {
        _mbsTrackClient = mbsTrackClient;
        _goUploadTrackClient = goUploadTrackClient;
    }
    [HttpPost]
    public async Task<IActionResult> CreateTrack(
        [FromForm] CreateTrackRequestDto request,
        CancellationToken token)
    {
        // TODO: remove for production
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        var responseGo = await _goUploadTrackClient.UploadTrackAsync(
            await CreateUploadTrackGrpcRequest(request), cancellationToken: token);
        // тест var responseGo = new UploadTrackResponse();
        // Отправляем запрос в бизнес-логику
        var response = await _mbsTrackClient.CreateTrackAsync(
            CreateTrackGrpcRequest(request, responseGo), cancellationToken: token);

        return Ok(response);
    }
    private async Task<UploadTrackRequest> CreateUploadTrackGrpcRequest(
        CreateTrackRequestDto request)
    {
        var bytes = await CreateBytes(request.Audio);

        return new UploadTrackRequest
        {
            FileName = request.Audio.FileName,
            ContentType = request.Audio.ContentType,
            File = ByteString.CopyFrom(bytes)
        };
    }
    private CreateTrackRequest CreateTrackGrpcRequest(
        CreateTrackRequestDto request, UploadTrackResponse response)
    {
        return new CreateTrackRequest
        {
            Title = request.Title,
            AlbumId = request.AlbumId,
            Duration = response.Duration,
            FileId = response.FileId
        };
    }

    private async Task<byte[]> CreateBytes(IFormFile request)
    {
        using var stream = new MemoryStream();

        await request.CopyToAsync(stream);

        return stream.ToArray();
    }

    //public class UploadTrackResponse
    //{
    //    public int Duration = 6;
    //    public int FileId = 3;
    //}
}
