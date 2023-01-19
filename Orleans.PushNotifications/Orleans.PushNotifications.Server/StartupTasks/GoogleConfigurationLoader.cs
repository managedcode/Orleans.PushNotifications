using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Server.ConfigurationProviders;
using Orleans.Runtime;

namespace Orleans.PushNotifications.Server.StartupTasks
{
    public class GoogleConfigurationLoader : IStartupTask
    {
        private readonly IGoogleConfigurationProvider _googleConfigurationProvider;
        private readonly GoogleConfiguration _googleConfiguration;

        private async ValueTask LoadConfiguration()
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

        public GoogleConfigurationLoader(
            IGoogleConfigurationProvider googleConfigurationProvider, 
            GoogleConfiguration googleConfiguration)
        {
            _googleConfigurationProvider = googleConfigurationProvider;
            _googleConfiguration = googleConfiguration;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            await LoadConfiguration();
        }
    }
}
