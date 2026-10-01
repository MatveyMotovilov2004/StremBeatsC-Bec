using Catalog.Domain;

namespace Catalog.Domain
{
    public class Album
    {
        public int Id { get; private set; }
        public ICollection<Track> Track 
            { get; private set; } = new List<Track>();
    }
}
