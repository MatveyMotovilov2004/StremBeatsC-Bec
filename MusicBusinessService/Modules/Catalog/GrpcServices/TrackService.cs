using Grpc.Core;
using Tracks;
using MediatR;
using Catalog.Application.Tracks;
using Catalog.Application.Tracks.CreateTrack;

namespace MusicBusinessService.Modules.Catalog.GrpcServices
{
    public class TrackService : TrackGrpcService.TrackGrpcServiceBase
    {
        private readonly IMediator _mediator;
        public TrackService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<CreateTrackResponse> CreateTrack
            (CreateTrackRequest request, ServerCallContext context)
        {
            var id = await _mediator.Send(
                new CreateTrackCommand(
                    request.Title, request.AlbumId, request.Duration, request.FileId
                ));
            return new CreateTrackResponse
            {
                Id = id,
                Status = "Created"
            };
        }

        public override async Task<DeleteTrackResponse> DeleteTrack
            (DeleteTrackRequest request, ServerCallContext context)
        {
            return new DeleteTrackResponse
            {
                IsSuccess = true
            };
        }
    }
}
