using Orleans.PushNotifications.Core.Models.Enums;

namespace Orleans.PushNotifications.Core.Models;

[GenerateSerializer]
public struct DeviceRegistration
{
    [Id(0)]
    public string DeviceToken { get; set; }
    [Id(1)]
    public PushPlatforms Platform { get; set; }
    public DeviceRegistration(string deviceToken, PushPlatforms platform)
    {
        DeviceToken = deviceToken;
        Platform = platform;
    }
}
