using Catalog.Domain;
using Catalog.Infrastructure.Persistence;
using MediatR;
using MusicBusinessService.Modules.Catalog;


namespace Catalog.Application.Tracks.CreateTrack;

public class CreateTrackHendler
    : IRequestHandler<CreateTrackCommand, int>, ICatalogHandler
{
    private readonly CatalogDbContext _db;

    public CreateTrackHendler(CatalogDbContext db)
    {
        _db = db;
    }
    public async Task<int> Handle(
        CreateTrackCommand request, 
        CancellationToken ct)
    {
        var track = new Track(
            request.title, request.albumId, request.durationInSeconds, request.fileId);
        
        _db.Add(track);
        await _db.SaveChangesAsync(ct);

        return track.Id;
    }
}

