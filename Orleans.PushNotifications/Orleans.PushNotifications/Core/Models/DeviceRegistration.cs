using Orleans.PushNotifications.Core.Models.Enums;

namespace Orleans.PushNotifications.Core.Models
{
    public struct DeviceRegistration
    {
        public DeviceRegistration(string deviceToken, PushPlatforms platform)
        {
            DeviceToken = deviceToken;
            Platform = platform;
        }
        public string DeviceToken { get; set; }
        public PushPlatforms Platform { get; set; }
    }
}
