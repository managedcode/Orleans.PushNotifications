using ManagedCode.Communication;
using Orleans.PushNotifications.Apple.Models;

namespace Orleans.PushNotifications.Server.ConfigurationProviders;

public interface IAppleConfigurationProvider
{
   ValueTask<Result<AppleConfiguration>> LoadConfiguration();
}