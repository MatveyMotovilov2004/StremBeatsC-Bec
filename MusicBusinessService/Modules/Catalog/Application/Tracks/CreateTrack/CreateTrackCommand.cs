using MediatR;

namespace Catalog.Application.Tracks.CreateTrack;

public record CreateTrackCommand
    (string title, int albumId, int durationInSeconds, int fileId): IRequest<int>;
