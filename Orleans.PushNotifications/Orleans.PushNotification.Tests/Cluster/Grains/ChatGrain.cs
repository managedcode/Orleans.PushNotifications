using ManagedCode.Communication;
using Orleans.PushNotification.Tests.Cluster.Grains.Interfaces;
using Orleans.PushNotification.Tests.Constants;
using Orleans.PushNotifications.Core.Interfaces.Grains;
using Orleans.PushNotifications.Core.Models;
using Orleans.PushNotifications.Core.Models.Enums;

namespace Orleans.PushNotification.Tests.Cluster.Grains
{
    public class ChatGrain : Grain, IChatGrain
    {
        public async Task<Result<DeviceRegistration>> SendTestMessage()
        {
            var pushGrain = GrainFactory.GetGrain<IPushNotificationGrain>(Guid.Empty.ToString());
            DeviceRegistration device = new DeviceRegistration
            {
                DeviceToken = TokensForTesting.DevicePushTokens,
                Platform = PushPlatforms.Google
            };
            PushNotifications.Core.Models.PushNotification pushNotification = new PushNotifications.Core.Models.PushNotification()
            {
                Title = "TEST ALERT",
                Message = "TEST"
            };
            var result = await pushGrain.SendPushNotification(device, pushNotification);
            return result;
        }
    }
}
