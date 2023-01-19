using Orleans.PushNotifications.Core.Interfaces.Base;

namespace Orleans.PushNotifications.Core.Interfaces;

public interface IPushSender<in TRequest, TResponse> : IBasePushSender
{
}