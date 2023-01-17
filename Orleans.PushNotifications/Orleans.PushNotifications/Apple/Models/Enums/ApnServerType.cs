using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Apple.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApnServerType
{
    Production,
    Development
}