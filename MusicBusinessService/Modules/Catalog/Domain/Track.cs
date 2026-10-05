using Catalog.Domain;

namespace Catalog.Domain
{
    public class Track
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = null!;
        public int AlbumId { get; private set; }
        public Album Album { get; private set; } = null!;
        public int Duration { get; private set; }
        public int FileId { get; private set; }
        public int playCount { get; private set; }

        private Track() { }

        public Track(string title, int albumId, int durationInSeronds, int fileId)
        {
            Title = title;
            AlbumId = albumId;
            Duration = durationInSeronds;
            FileId = fileId;
        }
    }
}
