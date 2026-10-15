namespace Identity.Infrastructure.Authentication;

public class JwtOptions
{
    // чем подписываем?
    public string Secret { get; set; } = string.Empty;
    // кто выпустил?
    public string Issuer { get; set; } = string.Empty;
    // для кого?
    public string Audience { get; set; } = string.Empty;
    // сколько живёт?
    public int ExpirstionMinutes { get; set; }
    // Сколько дней должен быть действителен refresh token
    public int RefreshTokenExpirationDays { get; set; }
}
