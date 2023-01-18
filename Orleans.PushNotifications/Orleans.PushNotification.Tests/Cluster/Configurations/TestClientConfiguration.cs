using Microsoft.Extensions.Configuration;
using Orleans.TestingHost;

namespace Orleans.PushNotification.Tests.Cluster.Configurations
{
    public class TestClientConfiguration : IClientBuilderConfigurator
    {
        public void Configure(IConfiguration configuration, IClientBuilder clientBuilder)
        {

        }
    }
}
