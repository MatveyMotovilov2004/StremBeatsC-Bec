namespace WebAPI.Dto
{
    public sealed class CreateTrackRequestDto
    {
        public string Title { get; init; } = null!;
        public int AlbumId { get; init; }
        public IFormFile Audio { get; init; } = null!;
    }
}
