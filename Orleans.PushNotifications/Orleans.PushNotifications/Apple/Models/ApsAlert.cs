using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Apple.Models;

public class ApsAlert
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("title-loc-key")]
    public string? TitleLocKey { get; set; }

    [JsonPropertyName("title-loc-args")]
    public string[]? TitleLocArgs { get; set; }

    [JsonPropertyName("subtitle")]
    public string? Subtitle { get; set; }

    [JsonPropertyName("subtitle-loc-key")]
    public string? SubtitleLocKey { get; set; }

    [JsonPropertyName("subtitle-loc-args")]
    public string[]? SubtitleLocArgs { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("launch-image")]
    public string? LaunchImage { get; set; }
}