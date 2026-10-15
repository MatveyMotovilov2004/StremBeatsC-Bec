namespace Artist.Domain
{
    public class Artist
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string StageName { get; private set; } = null!;
        public string? Description { get; private set; }

        private Artist() { }

        public Artist(int userId, string stageName)
        {
            UserId = userId;
            StageName = stageName;
        }
    }
}
