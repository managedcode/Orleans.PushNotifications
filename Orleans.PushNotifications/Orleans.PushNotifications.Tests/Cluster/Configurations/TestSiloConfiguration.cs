using Microsoft.Extensions.DependencyInjection;
using Orleans.PushNotifications.Google.Models;
using Orleans.Serialization;
using Orleans.TestingHost;

namespace Orleans.PushNotifications.Tests.Cluster.Configurations;

public class TestSiloConfiguration : ISiloConfigurator
{
    public void Configure(ISiloBuilder siloBuilder)
    {
        siloBuilder.Services.AddSerializer(serializerBuilder => { serializerBuilder.AddJsonSerializer(); });
        
        siloBuilder.ConfigureServices(services => 
        {
            services.AddSingleton(new GoogleConfiguration()
            {
                SenderId = "1"
            });
            
            services.AddSingleton(new GoogleConfiguration()
            {
                SenderId = "2"
            });
        });
    }
}