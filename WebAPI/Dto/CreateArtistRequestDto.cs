namespace WebAPI.Dto
{
    public class CreateArtistRequestDto
    {
        public int UserId { get; set; }
        public string StageName { get; set; } = null!;
    }
}
