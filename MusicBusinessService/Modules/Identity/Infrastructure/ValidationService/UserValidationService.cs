using Identity.Application;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.ValidationService;

public class UserValidationService : IUserValidationService
{
    private readonly IdentityDbContext _db;

    public UserValidationService(
        IdentityDbContext db)
    {
        _db = db;
    }
    public Task<bool> IsEmailAvailableAsync(
        string email, CancellationToken ct)
    {
        return;
    }

    public Task<bool> IsUserNameAvailableAsync(
        string userName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
