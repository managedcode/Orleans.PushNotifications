using ManagedCode.Communication;
using Orleans.Concurrency;
using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Core.Interfaces.Grains;
using Orleans.PushNotifications.Core.Models;

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

        public async Task<Result<DeviceRegistration>> SendPushNotification(
            string bundleId,
            DeviceRegistration deviceRegistration, 
            PushNotification pushNotification)
        {
            var result = await _pushNotificationsManager.SendPushAsync(bundleId, deviceRegistration, pushNotification);
            return result;
        }
    }
}
