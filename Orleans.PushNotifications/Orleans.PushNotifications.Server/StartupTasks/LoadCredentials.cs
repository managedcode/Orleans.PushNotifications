using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Server.ConfigurationProviders;
using Orleans.Runtime;

namespace Orleans.PushNotifications.Server.StartupTasks
{
    public class LoadCredentials : IStartupTask
    {
        private readonly IGoogleConfigurationProvider? _googleConfigurationProvider;
        //private readonly IAppleConfigurationProvider? _appleConfigurationProvider;
        private readonly GoogleConfiguration _googleConfiguration;
        private readonly AppleConfiguration _appleConfiguration;

        private async ValueTask LoadGoogleConfiguration()
        {
            var result = await _googleConfigurationProvider.LoadConfiguration();
            if (result.IsSuccess && result.Value is not null)
            {
                _googleConfiguration.IsLoaded = true;
                _googleConfiguration.SenderId = result.Value.SenderId;
                _googleConfiguration.ServerKey = result.Value.ServerKey;
                _googleConfiguration.DefaultChannelId = result.Value.DefaultChannelId;
            }
        }
        
        private async ValueTask LoadAppleConfiguration()
        {
            //var result = await _appleConfigurationProvider.LoadConfiguration();
            //if (result.IsSuccess && result.Value is not null)
            //{
            //    _appleConfiguration.IsLoaded = true;
            //    _appleConfiguration.P8PrivateKey = result.Value.P8PrivateKey;
            //    _appleConfiguration.ApnServerType = result.Value.ApnServerType;
            //    _appleConfiguration.P8PrivateKeyId = result.Value.P8PrivateKeyId;
            //    _appleConfiguration.AppBundleIdentifier = result.Value.AppBundleIdentifier;
            //    _appleConfiguration.TeamId = result.Value.TeamId;
            //    _appleConfiguration.TokenExpiration = result.Value.TokenExpiration;
            //}
        }

        public LoadCredentials(
            IGoogleConfigurationProvider googleConfigurationProvider, 
            GoogleConfiguration googleConfiguration)
        {
            _googleConfigurationProvider = googleConfigurationProvider;
            _googleConfiguration = googleConfiguration;
            //_appleConfigurationProvider = appleConfigurationProvider;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            if (_googleConfigurationProvider is not null)
                await LoadGoogleConfiguration();
            //if (_appleConfigurationProvider is not null)
            //    await LoadAppleConfiguration();
        }
    }
}
