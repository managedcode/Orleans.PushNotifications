using System.Text.Json.Serialization;

namespace Orleans.PushNotifications.Google.Models;

public class FcmResponse
{
    [JsonPropertyName("multicast_id")]
    public long MulticastId { get; set; }

    [JsonPropertyName("canonical_ids")]
    public long CanonicalIds { get; set; }

    [JsonPropertyName("success")]
    public int Success { get; set; }

    [JsonPropertyName("failure")]
    public int Failure { get; set; }

    [JsonPropertyName("results")]
    public List<FcmResult>? Results { get; set; }
}