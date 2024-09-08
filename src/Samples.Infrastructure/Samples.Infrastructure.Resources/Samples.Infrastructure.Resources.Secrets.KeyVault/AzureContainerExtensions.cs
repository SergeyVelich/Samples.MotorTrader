using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Samples.Infrastructure.Resources.Secrets.KeyVault;

public static class AzureContainerExtensions
{
    public static void AddAzureKeyVaultConfiguration(this ConfigurationManager configurationManager, string sectionName)
    {
        var keyVaultUri = new Uri($"https://{configurationManager[sectionName]}.vault.azure.net");
        configurationManager.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
    }
}