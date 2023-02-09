using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Exceptions;
using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Core;

public abstract class BasePushSender<TRequest, TResponse> : IPushSender<TRequest, TResponse>
{
    protected bool IsConfigured;
    public async Task<Result<DeviceRegistration>> SendPushAsync(
        string bundleId,
        DeviceRegistration deviceRegistration,
        PushNotification notification,
        CancellationToken cancellationToken = default)
    {
        if (!IsConfigured)
        {
            return Result<DeviceRegistration>.Fail(new NotInitializedException());
        }

        try
        {
            var push = ConvertPushNotification(bundleId, notification);
            return await SendPushNotificationAsync(bundleId, deviceRegistration, push, cancellationToken);
        }
        catch (Exception e)
        {
            return Result<DeviceRegistration>.Fail(e, deviceRegistration);
        }
    }

    protected abstract TRequest ConvertPushNotification(string bundleId, PushNotification notification);

    protected abstract Task<Result<DeviceRegistration>> SendPushNotificationAsync(
        string bundleId,
        DeviceRegistration deviceRegistration,
        TRequest notification,
        CancellationToken cancellationToken = default);
}