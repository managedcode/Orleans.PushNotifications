using Orleans.PushNotification.Tests.Cluster.Configurations;
using Orleans.TestingHost;
using Xunit;

namespace Orleans.PushNotification.Tests.Cluster
{
    [CollectionDefinition(nameof(TestClusterApplication))]
    public class TestClusterApplication : ICollectionFixture<TestClusterApplication>, IDisposable, IAsyncDisposable
    {
        public TestCluster Cluster { get; }

        public TestClusterApplication()
        {
            var builder = new TestClusterBuilder();
            builder.AddSiloBuilderConfigurator<TestSiloConfiguration>();
            builder.AddClientBuilderConfigurator<TestClientConfiguration>();
            Cluster = builder.Build();
            Cluster.Deploy();
        }

        public async ValueTask DisposeAsync()
        {
            await Cluster.DisposeAsync();
        }

        public void Dispose()
        {
            Cluster.Dispose();
        }
    }
}
