using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Server.ConfigurationProviders;
using Orleans.Runtime;

namespace Orleans.PushNotifications.Server.StartupTasks;

public class AppleConfigurationLoader : IStartupTask
{
    private readonly IAppleConfigurationProvider _appleConfigurationProvider;
    private readonly AppleConfiguration _appleConfiguration;

    private async ValueTask LoadConfiguration()
    {
        var result = await _appleConfigurationProvider.LoadConfiguration();
        if (result.IsSuccess && result.Value is not null)
        {
            _appleConfiguration.IsLoaded = true;
            _appleConfiguration.P8PrivateKey = result.Value.P8PrivateKey;
            _appleConfiguration.ApnServerType = result.Value.ApnServerType;
            _appleConfiguration.P8PrivateKeyId = result.Value.P8PrivateKeyId;
            _appleConfiguration.AppBundleIdentifier = result.Value.AppBundleIdentifier;
            _appleConfiguration.TeamId = result.Value.TeamId;
            _appleConfiguration.TokenExpiration = result.Value.TokenExpiration;
        }
    }
    
    public AppleConfigurationLoader(IAppleConfigurationProvider appleConfigurationProvider, AppleConfiguration appleConfiguration)
    {
        _appleConfigurationProvider = appleConfigurationProvider;
        _appleConfiguration = appleConfiguration;
    }

    public async Task Execute(CancellationToken cancellationToken)
    {
        await LoadConfiguration();
    }
}