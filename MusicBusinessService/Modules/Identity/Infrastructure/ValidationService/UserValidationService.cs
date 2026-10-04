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
    public async Task<bool> IsEmailAvailableAsync(
        string email, CancellationToken ct)
    {
        return !await _db.user
            .AsNoTracking()
            .AnyAsync( x => x.Email == email, ct);
    }

    public async Task<bool> IsUserNameAvailableAsync(
        string userName, CancellationToken ct)
    {
        return !await _db.user
            .AsNoTracking()
            .AnyAsync(x => x.UserName == userName, ct);
    }
}
