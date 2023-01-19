using ManagedCode.Communication;
using Orleans.PushNotifications.Google.Models;

namespace Orleans.PushNotifications.Server.ConfigurationProviders;

public interface IGoogleConfigurationProvider
{
    ValueTask<Result<GoogleConfiguration>> LoadConfiguration();
}