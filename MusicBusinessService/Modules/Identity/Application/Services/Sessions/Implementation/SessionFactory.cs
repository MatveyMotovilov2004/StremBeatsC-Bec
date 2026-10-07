using Identity.Domain;
using Identity.Application.Services.Sessions.Contract;

namespace Identity.Application.Services.Sessions.Implementation;

public class SessionFactory : ISessionFactory
{
    public Session Create(User user)
    {
        var now = DateTime.UtcNow;

        return new Session
        {
            User = user,
            CreatedAt = now,
            LastActivityAt = now,
            RevokedAt = null
        };
    }
}
