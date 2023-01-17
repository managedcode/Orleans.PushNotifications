using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Google.Models;

public class GeneralNotification
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}