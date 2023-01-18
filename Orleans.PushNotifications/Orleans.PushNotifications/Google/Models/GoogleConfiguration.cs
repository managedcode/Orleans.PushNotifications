namespace Orleans.PushNotifications.Google.Models;

public class GoogleConfiguration
{
    public string SenderId { get; set; }
    public string ServerKey { get; set; }
    public string? DefaultChannelId { get; set; }
    public bool IsLoaded { get; set; }

    public void Validate()
    {
        ArgumentNullException.ThrowIfNull(SenderId);
        ArgumentNullException.ThrowIfNull(ServerKey);
    }
}
