using ManagedCode.Communication;
using Orleans.Concurrency;
using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Core.Models;
using Orleans.PushNotifications.Server.Grains.Interfaces;

namespace Orleans.PushNotifications.Server.Grains
{
    [StatelessWorker]
    public class PushNotificationGrain : Grain, IPushNotificationGrain
    {
        private readonly IPushNotificationsManager _pushNotificationsManager;

        public PushNotificationGrain(IPushNotificationsManager pushNotificationsManager)
        {
            _pushNotificationsManager = pushNotificationsManager;
        }

        public async Task<Result<DeviceRegistration>> SendPushNotification(DeviceRegistration deviceRegistration, PushNotification pushNotification)
        {
            var result = await _pushNotificationsManager.SendPushAsync(deviceRegistration, pushNotification);
            return result;
        }
    }
}
