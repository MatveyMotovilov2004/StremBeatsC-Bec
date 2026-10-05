namespace Identity.Application;

public interface IPasswordServise
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
