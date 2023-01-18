using Orleans.PushNotification.Tests.Cluster.Grains.Interfaces;

namespace Orleans.PushNotification.Tests.Cluster.Grains
{
    public class ChatGrain : Grain, IChatGrain
    {
        public Task SendTestMessage()
        {
            return Task.CompletedTask;
        }
    }
}
