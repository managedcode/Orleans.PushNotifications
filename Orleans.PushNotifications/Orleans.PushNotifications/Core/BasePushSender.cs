using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Exceptions;
using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Core.Models;

namespace Orleans.PushNotifications.Core;

public abstract class BasePushSender<TRequest, TResponse> : IPushSender<TRequest, TResponse>
{
    protected bool IsConfigured;
    public async Task<Result<DeviceRegistration>> SendPushAsync(
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
            var push = ConvertPushNotification(notification);
            return await SendPushNotificationAsync(deviceRegistration, push, cancellationToken);
        }
        catch (Exception e)
        {
            return Result<DeviceRegistration>.Fail(e, deviceRegistration);
        }
    }

    protected abstract TRequest ConvertPushNotification(PushNotification notification);

    protected abstract Task<Result<DeviceRegistration>> SendPushNotificationAsync(DeviceRegistration deviceRegistration,
        TRequest notification,
        CancellationToken cancellationToken = default);
}