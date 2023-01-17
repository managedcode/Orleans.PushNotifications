using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Apple.Models;

public class Aps
{
    /// <summary>
    ///     The information for displaying an alert. A dictionary is recommended. If you specify a string, the alert displays
    ///     your string as the body text
    /// </summary>
    [JsonPropertyName("alert")]
    public ApsAlert? Alert { get; set; }

    /// <summary>
    ///     The number to display in a badge on your app’s icon. Specify 0 to remove the current badge, if any
    /// </summary>
    [JsonPropertyName("badge")]
    public int? Badge { get; set; }

    /// <summary>
    ///     The notification service app extension flag.If the value is 1, the system passes the notification to your
    ///     notification service app extension before delivery.Use your extension to modify the notification’s content
    /// </summary>
    [JsonPropertyName("mutable-content")]
    public int? MutableContent { get; set; }

    /// <summary>
    ///     A dictionary that contains sound information for critical alerts. For regular notifications, use the sound string
    ///     instead.
    /// </summary>
    [JsonPropertyName("sound")]
    public string? Sound { get; set; } // TODO: string or dictionary for critical

    /// <summary>
    ///     The background notification flag. To perform a silent background update, specify the value 1 and don’t include the
    ///     alert, badge, or sound keys in your payload
    /// </summary>
    [JsonPropertyName("content-available")]
    public int? ContentAvailable { get; set; }

    /// <summary>
    ///     The identifier of the window brought forward.The value of this key will be populated on the UNNotificationContent
    ///     object created from the push payload. Access the value using the UNNotificationContent object’s
    ///     targetContentIdentifier property
    /// </summary>
    [JsonPropertyName("target-content-id")]
    public string? TargetContentId { get; set; }

    /// <summary>
    ///     The relevance score, a number between 0 and 1, that the system uses to sort the notifications from your app.The
    ///     highest score gets featured in the notification summar
    /// </summary>
    [JsonPropertyName("relevance-score")]
    public double? RelevanceScore { get; set; }

    /// <summary>
    ///     The notification’s type.This string must correspond to the identifier of one of the UNNotificationCategory objects
    ///     you register at launch time
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    ///     An app-specific identifier for grouping related notifications. This value corresponds to the threadIdentifier
    ///     property in the UNNotificationContent object
    /// </summary>
    [JsonPropertyName("thread-id")]
    public string? ThreadId { get; set; }

    /// <summary>
    ///     A string that indicates the importance and delivery timing of a notification. The string values “passive”,
    ///     “active”, “time-sensitive”, or “critical” correspond to the UNNotificationInterruptionLevel enumeration cases
    /// </summary>
    [JsonPropertyName("interruption-level")]
    public string? InterruptionLevel { get; set; } = "active";
}