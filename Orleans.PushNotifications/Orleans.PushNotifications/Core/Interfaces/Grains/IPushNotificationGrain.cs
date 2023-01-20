using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Core.Interfaces.Grains
{
    public interface IPushNotificationGrain : IGrainWithStringKey
    {
        Task<Result<DeviceRegistration>> SendPushNotification(string bundleId, DeviceRegistration deviceRegistration, PushNotification pushNotification);
    }
}
