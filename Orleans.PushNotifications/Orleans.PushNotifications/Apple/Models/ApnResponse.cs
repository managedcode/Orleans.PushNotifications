using Orleans.PushNotifications.Apple.Models.Enums;

namespace Orleans.PushNotifications.Apple.Models;

public class ApnResponse
{
    public ApnReasonEnum? Reason { get; set; }
    public long? Timestamp { get; set; }
}