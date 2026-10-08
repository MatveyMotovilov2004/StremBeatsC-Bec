namespace Identity.Infrastructure.Authentication;

public class JwtOptions
{
    // чем подписываем?
    public string Secret { get; set; } = null!;
    // кто выпустил?
    public string Issuer { get; set; } = null!;
    // для кого?
    public string Audience { get; set; } = null!;
    // сколько живёт?
    public int ExpirstionMinutes { get; set; }
    // Сколько дней должен быть действителен refresh token
    public int RefreshTokenExpirationDays { get; set; }
}
