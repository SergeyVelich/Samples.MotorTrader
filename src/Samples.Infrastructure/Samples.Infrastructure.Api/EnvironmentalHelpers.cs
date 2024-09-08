namespace Samples.Infrastructure.Api;

public static class EnvironmentHelpers
{
    public const string LocalDevelopment = "LocalDevelopment";

    public static bool IsLocalDevelopment()
    {
        var environmentVariableValue = Environment.GetEnvironmentVariable(LocalDevelopment);
        if (bool.TryParse(environmentVariableValue, out var isLocalDevelopment))
        {
            return isLocalDevelopment;
        }

        return false;
    }
}