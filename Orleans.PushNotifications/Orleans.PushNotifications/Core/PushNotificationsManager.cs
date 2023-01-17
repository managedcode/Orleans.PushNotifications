using ManagedCode.Communication;
using Orleans.PushNotifications.Apple.Senders.Interfaces;
using Orleans.PushNotifications.Core.Exceptions;
using Orleans.PushNotifications.Core.Interfaces.Base;
using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Core.Models.Enums;
using Orleans.PushNotifications.Core.Models;
using Orleans.PushNotifications.Google.Senders.Interfaces;

namespace Orleans.PushNotifications.Core;


public class PushNotificationsManager : IPushNotificationsManager
{
    private readonly IApplePushSender? _applePushSender;
    private readonly IGooglePushSender? _googlePushSender;

    public PushNotificationsManager(IServiceProvider serviceProvider) //IApplePushSender? applePushSender, IGooglePushSender? googlePushSender)
    {
        _applePushSender = serviceProvider.GetService(typeof(IApplePushSender)) as IApplePushSender;
        _googlePushSender = serviceProvider.GetService(typeof(IGooglePushSender)) as IGooglePushSender;
    }

    public async Task<Result<DeviceRegistration>> SendPushAsync(DeviceRegistration deviceRegistration,
        PushNotification notification,
        CancellationToken cancellationToken = default)
    {
        IBasePushSender? sender = deviceRegistration.Platform switch
        {
            PushPlatforms.Apple => _applePushSender,
            PushPlatforms.Google => _googlePushSender,
            _ => throw new ArgumentOutOfRangeException()
        };

        if (sender is null)
        {
            Result<DeviceRegistration>.Fail(new NotInitializedException(deviceRegistration.Platform.ToString()));
        }

        return await sender!.SendPushAsync(deviceRegistration, notification, cancellationToken);
    }

    public async Task<Result<DeviceRegistration>[]> SendPushAsync(DeviceRegistration[] deviceRegistrations,
        PushNotification notification,
        CancellationToken cancellationToken = default)
    {
        var results = new List<Result<DeviceRegistration>>(deviceRegistrations.Length);
        foreach (var device in deviceRegistrations)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await SendPushAsync(device, notification, cancellationToken);
            results.Add(result);
        }

        return results.ToArray();
    }

    public async Task<Result<DeviceRegistration>[]> SendPushAsync(DeviceRegistration deviceRegistration,
        PushNotification[] notifications,
        CancellationToken cancellationToken = default)
    {
        var results = new List<Result<DeviceRegistration>>(notifications.Length);
        foreach (var message in notifications)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = await SendPushAsync(deviceRegistration, message, cancellationToken);
            results.Add(result);
        }

        return results.ToArray();
    }

    public async Task<Result<DeviceRegistration>[]> SendPushAsync(DeviceRegistration[] deviceRegistrations,
        PushNotification[] notifications,
        CancellationToken cancellationToken = default)
    {
        var results = new List<Result<DeviceRegistration>>(deviceRegistrations.Length * notifications.Length);

        foreach (var device in deviceRegistrations)
        {
            foreach (var message in notifications)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var result = await SendPushAsync(device, message, cancellationToken);
                results.Add(result);
            }
        }

        return results.ToArray();
    }
}