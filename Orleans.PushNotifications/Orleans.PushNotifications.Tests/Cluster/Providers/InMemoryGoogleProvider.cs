using ManagedCode.Communication;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Server.ConfigurationProviders;

namespace Orleans.PushNotifications.Tests.Cluster.Providers
{
    public class InMemoryGoogleConfigurationProvider : IGoogleConfigurationProvider
    {
        public ValueTask<Result<GoogleConfiguration>> LoadConfiguration()
        {
            var googleConfiguration = new GoogleConfiguration();
            return ValueTask.FromResult(Result.Succeed(googleConfiguration));
        }
    }
}
