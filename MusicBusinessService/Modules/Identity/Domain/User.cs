namespace Identity.Domain;

public class User
{
    public int Id { get; private set; }
    public string UserName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public ICollection<Role> Roles { get; set; } 
        = new List<Role>();
    public ICollection<Session> Sessions { get; set; }
        = new List<Session>();

    private User() { }

    public User(string userName, string email, string passwordHash)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

}
