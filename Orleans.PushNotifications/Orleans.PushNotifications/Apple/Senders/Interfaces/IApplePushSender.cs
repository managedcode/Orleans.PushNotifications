using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Core.Interfaces;

namespace Orleans.PushNotifications.Apple.Senders.Interfaces;

public interface IApplePushSender : IPushSender<AppleNotification, ApnResponse>
{
}