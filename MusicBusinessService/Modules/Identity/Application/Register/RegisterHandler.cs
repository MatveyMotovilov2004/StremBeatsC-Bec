using Identity.Application.Register;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;


namespace MusicBusinessService.Modules.Identity.Application.Register;

public class RegisterHandler
    : IRequestHandler<RegisterCommand, int>
{
    private readonly IdentityDbContext _db;

    public RegisterHandler(IdentityDbContext db)
    {
        _db = db;
    }
    public async Task<int> Handle(
        RegisterCommand request, 
        CancellationToken ct)
    {
        _db.Add(new User(
            request.email, request.passwordHash));
        await _db.SaveChangesAsync(ct);

        return;
    }
}
