using Identity.Domain;

namespace Identity.Application.Services.Sessions.Contract;

public interface ISessionFactory
{
    Session Create(User user);
}
