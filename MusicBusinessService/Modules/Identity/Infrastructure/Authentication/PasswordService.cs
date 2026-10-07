using Microsoft.AspNetCore.Identity;
using MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;

namespace Identity.Infrastructure.Authentication;

public class PasswordService : IPasswordServise
{
    private readonly PasswordHasher<object> _hasher = new();
    public string Hash(string password)
    {
        return _hasher.HashPassword(null!, password);
    }

    public bool Verify(string password, string passwordHash)
    {
        var result = _hasher.VerifyHashedPassword(
            null!, passwordHash, password);
        return result != PasswordVerificationResult.Failed;
    }
}
