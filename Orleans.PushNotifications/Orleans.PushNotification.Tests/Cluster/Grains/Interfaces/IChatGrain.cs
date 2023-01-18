namespace Orleans.PushNotification.Tests.Cluster.Grains.Interfaces
{
    public interface IChatGrain : IGrainWithStringKey
    {
        public Task SendTestMessage();
    }
}
