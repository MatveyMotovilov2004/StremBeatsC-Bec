namespace MusicBusinessService.Modules.Identity.Application.Services.InfrastructureContract;

public interface IPasswordServise
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
