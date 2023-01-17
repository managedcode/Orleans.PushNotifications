using Orleans.PushNotifications.Google.Models.Enums;
using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Google.Models;

public class GoogleAndroidConfig
{
    [JsonPropertyName("ttl")]
    public string? TTL { get; set; }

    [JsonPropertyName("priority")]
    public AndroidMessagePriority? Priority { get; set; }

    [JsonPropertyName("collapse_key")]
    public string? CollapseKey { get; set; }

    [JsonPropertyName("restricted_package_name")]
    public string? RestrictedPackageName { get; set; }

    [JsonPropertyName("direct_boot_ok")]
    public bool? DirectBootOk { get; set; }

    [JsonPropertyName("notification")]
    public GoogleAndroidNotificationDetails? Notification { get; set; }
}