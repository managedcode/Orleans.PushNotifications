using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Server.Extensions;
using Orleans.Serialization;
using Orleans.TestingHost;

namespace Orleans.PushNotifications.Tests.Cluster.Configurations;

public class TestSiloConfiguration : ISiloConfigurator
{
    public void Configure(ISiloBuilder siloBuilder)
    {
        var androidConfig = new GoogleConfiguration
        {
            SenderId = "515769829200",
            ServerKey = "AAAAeBZHB1A:APA91bE0y15dQv4oJ6QY9Lugaw7SdYNon5Vs41MQGSdpo0LLxribYgvtUIAPWxCwegyVPJdQxVAyvJQE1DrgFUyBQqc2sTJBles4A1_qxGGc2F8M9xMllqelwZeqMSol5IptJ3XQkBTW"
        };

        siloBuilder.Services.AddSerializer(serializerBuilder => { serializerBuilder.AddJsonSerializer(); });

        siloBuilder.ConfigureServices(services => 
        {
            services.AddAndroidPushNotifications(androidConfig);
        });
    }
}