using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Google.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AndroidMessagePriority
{
    Normal,
    High
}
