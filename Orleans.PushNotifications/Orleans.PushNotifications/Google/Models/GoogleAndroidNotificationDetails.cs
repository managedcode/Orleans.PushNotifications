using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Google.Models;

public class GoogleAndroidNotificationDetails
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("icon")]
    public string? Icon { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("sound")]
    public string? Sound { get; set; }

    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("click_action")]
    public string? ClickAction { get; set; }

    [JsonPropertyName("body_loc_key")]
    public string? BodyLocKey { get; set; }

    [JsonPropertyName("body_loc_args")]
    public string[]? BodyLocArgs { get; set; }

    [JsonPropertyName("title_loc_key")]
    public string? TitleLocKey { get; set; }

    [JsonPropertyName("title_loc_args")]
    public string[]? TitleLocArgs { get; set; }

    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; set; }

    [JsonPropertyName("ticker")]
    public string? Ticker { get; set; }

    [JsonPropertyName("sticky")]
    public bool? Sticky { get; set; }

    [JsonPropertyName("event_time")]
    public string? EventTime { get; set; }

    [JsonPropertyName("local_only")]
    public bool? LocalOnly { get; set; }

    [JsonPropertyName("default_sound")]
    public bool? DefaultSound { get; set; }

    [JsonPropertyName("default_vibrate_timings")]
    public bool? DefaultVibrateTimings { get; set; }

    [JsonPropertyName("default_light_settings")]
    public bool? DefaultLightSettings { get; set; }

    [JsonPropertyName("bypass_proxy_notification")]
    public bool? BypassProxyNotification { get; set; }

    [JsonPropertyName("notification_count")]
    public int? NotificationCount { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

}