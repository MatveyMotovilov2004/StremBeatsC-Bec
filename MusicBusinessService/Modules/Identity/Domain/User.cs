using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Identity.Domain;

public class User
{
    public int Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
        = new List<RefreshToken>();

    private User() { }

    public User(string userName, string email, string passwordHash)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

}
