using ManagedCode.Communication;
using Orleans.PushNotifications.Core.Models;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Google.Senders.Interfaces;
using System.Text.Json;
using System.Text;
using Orleans.PushNotifications.Core;

namespace Orleans.PushNotifications.Google.Senders;

public class GooglePushSender : BasePushSender<GoogleNotification, FcmResponse>, IGooglePushSender
{
    private const string FcmUrl = "https://fcm.googleapis.com/fcm/send";
    private readonly Dictionary<string, GoogleConfiguration> _googleConfigurations;
    private readonly HttpClient _httpClient;

    public GooglePushSender(IEnumerable<GoogleConfiguration> configurations)
    {
        if (configurations is null)
        {
            IsConfigured = false;
            return;
        }

        _googleConfigurations = configurations.ToDictionary(config => config.SenderId);
        IsConfigured = true;

        _httpClient = new HttpClient();
    }

    protected override GoogleNotification ConvertPushNotification(string bundleId, PushNotification notification)
    {
        _googleConfigurations.TryGetValue(bundleId, out var configuration);
        
        var googleNotification = new GoogleNotification
        {
            Data = notification.Data,
            Notification = new GeneralNotification
            {
                Title = notification.Title,
                Body = notification.Message,
                Image = notification.ImageUri,
            },
            Android = new GoogleAndroidConfig
            {
                Notification = new GoogleAndroidNotificationDetails
                {
                    ChannelId = configuration.DefaultChannelId,
                    Title = notification.Title,
                    Body = notification.Message,
                    Image = notification.ImageUri,
                    NotificationCount = notification.Badge
                }
            }
        };
        return googleNotification;
    }

    protected override async Task<Result<DeviceRegistration>> SendPushNotificationAsync(
        string bundleId,
        DeviceRegistration device,
        GoogleNotification notification,
        CancellationToken cancellationToken = default)
    {
        notification.To = device.DeviceToken;
        notification.Token = device.DeviceToken;

        if (_googleConfigurations.TryGetValue(bundleId, out var configuration) is false)
        {
            return Result<DeviceRegistration>.Fail();
        }
        
        var json = JsonSerializer.Serialize(notification);

        using (var request = new HttpRequestMessage(HttpMethod.Post, FcmUrl))
        {
            request.Headers.Add("Authorization", $"key = {configuration.ServerKey}");
            request.Headers.Add("Sender", $"id = {configuration.SenderId}");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(responseString))
            {
                return Result<DeviceRegistration>.Fail(new Exception("Firebase notification error: " + responseString), device);
            }

            //TODO: check
            if (string.IsNullOrWhiteSpace(responseString))
            {
                return Result<DeviceRegistration>.Fail(new Exception("No response from firebase"), device);
            }

            var result = JsonSerializer.Deserialize<FcmResponse>(responseString)!;
            if (result.Success == 1 && result.Failure == 0)
            {
                return Result<DeviceRegistration>.Succeed(device);
            }

            return Result<DeviceRegistration>.Fail(new Exception(JsonSerializer.Serialize(result)), device);
        }
    }
}