using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Google.Models;

namespace Orleans.PushNotifications.Google.Senders.Interfaces;

public interface IGooglePushSender : IPushSender<GoogleNotification, FcmResponse>
{
}
