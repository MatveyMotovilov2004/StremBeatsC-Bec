namespace Identity.Domain;

public class RefreshToken
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public string Token { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreatedAt { get; set; }
    public Session Session { get; set; } = null!;
}
