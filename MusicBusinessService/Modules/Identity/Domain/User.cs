using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Identity.Domain;

public class User
{
    public int Id { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime DeletedAt { get; private set; }

    private User() { }

    public User(string email, string passwordHash)
    {
        Email = email;
        PasswordHash = passwordHash;
    }

}
