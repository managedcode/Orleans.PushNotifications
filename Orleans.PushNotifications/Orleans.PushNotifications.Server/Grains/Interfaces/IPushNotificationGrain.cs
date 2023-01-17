using ManagedCode.Communication;
using Orleans;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Server.Grains.Interfaces
{
    public interface IPushNotificationGrain : IGrainWithStringKey
    {
        Task<Result<DeviceRegistration>> SendPushNotification(DeviceRegistration deviceRegistration, PushNotification pushNotification);
    }
}
