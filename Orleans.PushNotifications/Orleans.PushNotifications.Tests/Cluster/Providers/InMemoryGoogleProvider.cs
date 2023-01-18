using ManagedCode.Communication;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Server.ConfigurationProviders;

namespace Orleans.PushNotifications.Tests.Cluster.Providers
{
    public class InMemoryGoogleConfigurationProvider : IGoogleConfigurationProvider
    {
        public ValueTask<Result<GoogleConfiguration>> LoadConfiguration()
        {
            var googleConfiguration = new GoogleConfiguration
            {
                IsLoaded= true,
                SenderId = "515769829200",
                ServerKey = "AAAAeBZHB1A:APA91bE0y15dQv4oJ6QY9Lugaw7SdYNon5Vs41MQGSdpo0LLxribYgvtUIAPWxCwegyVPJdQxVAyvJQE1DrgFUyBQqc2sTJBles4A1_qxGGc2F8M9xMllqelwZeqMSol5IptJ3XQkBTW"
            };
            return ValueTask.FromResult(Result.Succeed(googleConfiguration));
        }
    }
}
