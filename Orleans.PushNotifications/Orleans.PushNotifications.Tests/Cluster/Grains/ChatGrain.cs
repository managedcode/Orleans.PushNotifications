using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Interfaces.Grains;
using Orleans.PushNotifications.Core.Models;
using Orleans.PushNotifications.Core.Models.Enums;
using Orleans.PushNotifications.Tests.Cluster.Grains.Interfaces;
using Orleans.PushNotifications.Tests.Constants;

namespace Orleans.PushNotifications.Tests.Cluster.Grains;

public class ChatGrain : Grain, IChatGrain
{
    public async Task<Result<DeviceRegistration>> SendTestMessage()
    {
        // TODO: move bundle ids to some configuration
        var bundleId = "some app";
        var pushGrain = GrainFactory.GetGrain<IPushNotificationGrain>(Guid.Empty.ToString());
        DeviceRegistration device = new DeviceRegistration
        {
            DeviceToken = TokensForTesting.DevicePushTokens,
            Platform = PushPlatforms.Google
        };
        PushNotification pushNotification = new PushNotification()
        {
            Title = "TEST ALERT",
            Message = "TEST"
        };
        var result = await pushGrain.SendPushNotification(bundleId, device, pushNotification);
        return result;
    }
}