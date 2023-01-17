using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Apple.Models;

/// <summary>
///     https://developer.apple.com/documentation/usernotifications/setting_up_a_remote_notification_server/generating_a_remote_notification
/// </summary>
public class AppleNotification
{
    [JsonPropertyName("aps")]
    public Aps? Aps { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> CustomData { get; set; } = new();
}