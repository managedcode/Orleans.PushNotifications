using Orleans.PushNotification.Tests.Cluster.Grains.Interfaces;
using Xunit;

namespace Orleans.PushNotification.Tests.Cluster
{
    [Collection(nameof(TestClusterApplication))]
    public class PushNotificationsTests
    {
        private readonly TestClusterApplication _testApp;

        public PushNotificationsTests(TestClusterApplication testApp)
        {
            _testApp = testApp;
        }

        [Fact]
        public async Task MakeCallToGrain_WhenGrainExists_ReturnOk()
        {
            var chatId = Guid.NewGuid().ToString();
            var chatGrain = _testApp.Cluster.Client.GetGrain<IChatGrain>(chatId);
            await chatGrain.SendTestMessage();
        }
    }
}
