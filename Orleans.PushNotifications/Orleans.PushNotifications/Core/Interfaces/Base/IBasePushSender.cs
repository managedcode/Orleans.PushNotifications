using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Core.Interfaces.Base;

public interface IBasePushSender
{
    Task<Result<DeviceRegistration>> SendPushAsync(
        string bundleId,
        DeviceRegistration registration,
        PushNotification notification,
        CancellationToken cancellationToken = default);
}