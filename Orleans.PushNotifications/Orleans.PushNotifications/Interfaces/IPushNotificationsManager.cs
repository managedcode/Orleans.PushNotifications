using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Interfaces;

public interface IPushNotificationsManager
{
    Task<Result<DeviceRegistration>> SendPushAsync(DeviceRegistration deviceRegistration,
        PushNotification notification,
        CancellationToken cancellationToken = default);

    Task<Result<DeviceRegistration>[]> SendPushAsync(DeviceRegistration[] deviceRegistrations,
        PushNotification notification,
        CancellationToken cancellationToken = default);

    Task<Result<DeviceRegistration>[]> SendPushAsync(DeviceRegistration deviceRegistration,
        PushNotification[] notifications,
        CancellationToken cancellationToken = default);

    Task<Result<DeviceRegistration>[]> SendPushAsync(DeviceRegistration[] deviceRegistrations,
        PushNotification[] notifications,
        CancellationToken cancellationToken = default);
}