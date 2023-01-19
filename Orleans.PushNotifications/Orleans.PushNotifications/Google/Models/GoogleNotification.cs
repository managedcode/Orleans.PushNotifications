using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Google.Models;

//https://firebase.google.com/docs/reference/fcm/rest/v1/projects.messages
public class GoogleNotification
{
    [JsonPropertyName("to")]
    public string? To { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, string>? Data { get; set; }

    [JsonPropertyName("notification")]
    public GeneralNotification? Notification { get; set; }

    [JsonPropertyName("android")]
    public GoogleAndroidConfig? Android { get; set; }
}
