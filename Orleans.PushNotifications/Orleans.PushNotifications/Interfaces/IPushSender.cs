using Orleans.PushNotifications.Interfaces.Base;

namespace Orleans.PushNotifications.Interfaces;

public interface IPushSender<in TRequest, TResponse> : IBasePushSender
{
}