using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Interfaces
{
    public interface IBasePushSender
    {
        Task<Result<DeviceRegistration>> SendPushAsync(DeviceRegistration registration,
            PushNotification notification,
            CancellationToken cancellationToken = default);
    }
}
