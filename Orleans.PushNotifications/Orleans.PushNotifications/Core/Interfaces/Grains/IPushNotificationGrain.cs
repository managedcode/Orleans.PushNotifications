using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Core.Interfaces.Grains
{
    public interface IPushNotificationGrain : IGrainWithStringKey
    {
        Task<Result<DeviceRegistration>> SendPushNotification(DeviceRegistration deviceRegistration, PushNotification pushNotification);
    }
}
