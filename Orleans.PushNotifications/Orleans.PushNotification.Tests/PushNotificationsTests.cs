using FluentAssertions;
using Orleans.PushNotification.Tests.Cluster;
using Orleans.PushNotification.Tests.Cluster.Grains.Interfaces;
using Xunit;

namespace Orleans.PushNotification.Tests
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
        public async Task MakeCallToGrain_WhenGrainExistsAndPushTokenValid_ReturnOk()
        {
            // Arrange
            var chatId = Guid.NewGuid().ToString();
            var chatGrain = _testApp.Cluster.Client.GetGrain<IChatGrain>(chatId);
            
            // Act
            var result = await chatGrain.SendTestMessage();
            
            // Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
