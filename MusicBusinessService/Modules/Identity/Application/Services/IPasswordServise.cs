namespace MusicBusinessService.Modules.Identity.Application.Services;

public interface IPasswordServise
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
