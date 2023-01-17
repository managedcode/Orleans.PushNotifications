namespace Orleans.PushNotifications.Core.Models
{
    public class PushNotification
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? CategoryOrChannel { get; set; }
        public int? Badge { get; set; }
        public string? ImageUri { get; set; }
        public TimeSpan? Expiration { get; set; }
        public Dictionary<string, string>? Data { get; set; }

        public InterruptionLevels InterruptionLevel { get; set; }
    }

    public enum InterruptionLevels
    {
        Active,
        TimeSensitive,
        Critical
    }
}
