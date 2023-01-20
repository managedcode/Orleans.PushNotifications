using Microsoft.Extensions.DependencyInjection;
using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Extensions;

namespace Orleans.PushNotifications.Server.Extensions
{
    public static class OrleansPushNotificationsExtensions
    {
        public static void AddIosPushNotifications<TAppleProvider>(this ISiloBuilder siloBuilder, Action<AppleConfiguration> configuration)
        {
            var config = new AppleConfiguration();
            configuration?.Invoke(config);
            siloBuilder.Services.AddIosPushNotifications(config);
        }
        
        public static void AddAndroidPushNotifications<TAppleProvider>(this ISiloBuilder siloBuilder, Action<GoogleConfiguration> configuration)
        {
            var config = new GoogleConfiguration();
            configuration?.Invoke(config);
            siloBuilder.Services.AddAndroidPushNotifications(config);
        }
        
        public static void AddIosPushNotifications(this IServiceCollection serviceCollection,
            AppleConfiguration config)
        {
            serviceCollection.AddApplePushNotifications(config);
        }

        public static void AddAndroidPushNotifications(this IServiceCollection serviceCollection,
            GoogleConfiguration config)
        {
            serviceCollection.AddGooglePushNotifications(config);
        }
    }
}
