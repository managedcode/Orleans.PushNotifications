using Orleans.PushNotifications.Core.Models.Enums;

namespace Orleans.PushNotifications.Core.Models;

[GenerateSerializer]
public class PushNotification
{
    [Id(0)]
    public string? Title { get; set; }
    [Id(1)]
    public string? Message { get; set; }
    [Id(2)]
    public string? CategoryOrChannel { get; set; }
    [Id(3)]
    public int? Badge { get; set; }
    [Id(4)]
    public string? ImageUri { get; set; }
    [Id(5)]
    public TimeSpan? Expiration { get; set; }
    [Id(6)]
    public Dictionary<string, string>? Data { get; set; }
    [Id(7)]
    public InterruptionLevels InterruptionLevel { get; set; }
}