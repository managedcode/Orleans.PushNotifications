using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotification.Tests.Cluster.Grains.Interfaces
{
    public interface IChatGrain : IGrainWithStringKey
    {
        public Task<Result<DeviceRegistration>> SendTestMessage();
    }
}
