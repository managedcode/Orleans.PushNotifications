using ManagedCode.Communication;
using Orleans.PushNotifications.Apple.Models.Enums;
using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Apple.Senders.Interfaces;
using Orleans.PushNotifications.Apple.TokenProvider;
using Orleans.PushNotifications.Core.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using Orleans.PushNotifications.Core;

namespace Orleans.PushNotifications.Apple.Senders;

public class ApplePushSender : BasePushSender<AppleNotification, ApnResponse>, IApplePushSender
{
    private const string DevelopmentUrl = "https://api.development.push.apple.com";
    private const string ProductionUrl = "https://api.push.apple.com";
    private readonly AppleAuthTokenProvider _authTokenProvider;
    private readonly AppleConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public ApplePushSender(AppleConfiguration configuration)
    {
        if (configuration is null)
        {
            IsConfigured = false;
            return;
        }

        _configuration = configuration;
        _configuration.Validate();
        IsConfigured = true;

        _httpClient = new HttpClient();

        _authTokenProvider = new AppleAuthTokenProvider(_configuration);
    }

    protected override AppleNotification ConvertPushNotification(PushNotification notification)
    {
        var appleNotification = new AppleNotification
        {
            Aps = new Aps
            {
                Category = notification.CategoryOrChannel,
                Badge = notification.Badge,
                InterruptionLevel = notification.InterruptionLevel.ToString(),
                Sound = "default" //for default sound

            }
        };
        if (notification.Title != null || notification.Message != null)
        {
            appleNotification.Aps.Alert = new ApsAlert
            {
                Title = notification.Title,
                Body = notification.Message,
                LaunchImage = notification.ImageUri,
            };
        }

        if (notification.Data != null)
        {
            appleNotification.CustomData = new Dictionary<string, object>();
            foreach (var pair in notification.Data)
            {
                appleNotification.CustomData.Add(pair.Key, pair.Value);
            }

            appleNotification.Aps.ContentAvailable = 1;
        }

        return appleNotification;
    }

    protected override async Task<Result<DeviceRegistration>> SendPushNotificationAsync(
        string bundleId,
        DeviceRegistration deviceRegistration,
        AppleNotification notification,
        CancellationToken cancellationToken = default)
    {

        var server = _configuration.ApnServerType switch
        {
            ApnServerType.Production => ProductionUrl,
            ApnServerType.Development => DevelopmentUrl,
            _ => throw new ArgumentOutOfRangeException()
        };

        var url = $"{server}/3/device/{deviceRegistration.DeviceToken}";
        var json = JsonSerializer.Serialize(notification);

        var request = new HttpRequestMessage(HttpMethod.Post, new Uri(url))
        {
            Version = new Version(2, 0),
            Content = new StringContent(json)
        };

        var jwt = _authTokenProvider.GetAuthToken();
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", jwt);
        request.Headers.TryAddWithoutValidation("apns-id", $"{Guid.NewGuid():D}");
        request.Headers.TryAddWithoutValidation("apns-topic", _configuration.AppBundleIdentifier);
        request.Headers.TryAddWithoutValidation("apns-expiration", "0");

        var silentPush = notification.Aps.Alert == null && notification.Aps.ContentAvailable == 1;
        request.Headers.Add("apns-priority", silentPush ? "5" : "10");
        request.Headers.Add("apns-push-type", silentPush ? "background" : "alert");

        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            return Result<DeviceRegistration>.Succeed(deviceRegistration);
        }

        var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var apnResponse = JsonSerializer.Deserialize<ApnResponse>(content);
        var reason = apnResponse?.Reason;

        var reasonMessage = $"Reason:{reason};\n{content}";

        switch (reason)
        {
            case ApnReasonEnum.BadDeviceToken or ApnReasonEnum.Unregistered:
                return Result<DeviceRegistration>.Fail(new Exception(reasonMessage), deviceRegistration);
            case ApnReasonEnum.ExpiredProviderToken or ApnReasonEnum.InternalServerError
                or ApnReasonEnum.ServiceUnavailable or ApnReasonEnum.Shutdown:
                //TODO: add Retry when managedcode.communication will support it.
                break;
        }

        throw new Exception(reasonMessage);
    }
}