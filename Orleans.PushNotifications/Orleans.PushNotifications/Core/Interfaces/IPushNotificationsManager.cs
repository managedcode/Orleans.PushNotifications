using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Core.Interfaces;

public interface IPushNotificationsManager
{
    Task<Result<DeviceRegistration>> SendPushAsync(       
        string bundleId,
        DeviceRegistration deviceRegistration,
        PushNotification notification,
        CancellationToken cancellationToken = default);

    Task<Result<DeviceRegistration>[]> SendPushAsync(
        string bundleId,
        DeviceRegistration[] deviceRegistrations,
        PushNotification notification,
        CancellationToken cancellationToken = default);

    Task<Result<DeviceRegistration>[]> SendPushAsync(
        string bundleId,
        DeviceRegistration deviceRegistration,
        PushNotification[] notifications,
        CancellationToken cancellationToken = default);

    Task<Result<DeviceRegistration>[]> SendPushAsync(
        string bundleId,
        DeviceRegistration[] deviceRegistrations,
        PushNotification[] notifications,
        CancellationToken cancellationToken = default);
    
    // TODO: Add method with list of bundle ids(if we really need it)
}