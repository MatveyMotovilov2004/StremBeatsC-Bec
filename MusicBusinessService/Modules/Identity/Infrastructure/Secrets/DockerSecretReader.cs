namespace Identity.Infrastructure.Secrets;

public static class DockerSecretReader
{
    public static string ReadRequired(string secretName)
    {
        var path = Path.Combine("/run/secrets", secretName);

        if (!File.Exists(path))
        {
            throw new InvalidOperationException(
                $"Required Docker secret '{secretName}' is missing.");
        }

        var value = File.ReadAllText(path).Trim();

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException(
                $"Required Docker secret '{secretName}' is empty.");
        }

        return value;
    }
}
