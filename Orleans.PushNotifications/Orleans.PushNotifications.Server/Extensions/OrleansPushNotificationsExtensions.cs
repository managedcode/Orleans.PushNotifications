using Microsoft.Extensions.DependencyInjection;
using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Google.Models;
using Orleans.PushNotifications.Extensions;
using Orleans.PushNotifications.Server.ConfigurationProviders;
using Orleans.PushNotifications.Server.StartupTasks;

namespace Orleans.PushNotifications.Server.Extensions
{
    public static class OrleansPushNotificationsExtensions
    {
        // TODO: add configurations in secure way
        public static void AddIosPushNotifications(this IServiceCollection serviceCollection, AppleConfiguration config)
        {
            serviceCollection.AddApplePushNotifications(config);
        }
        
        public static void AddIosPushNotifications<TGoogleProvider>(this ISiloBuilder siloBuilder)
            where TGoogleProvider : class, IGoogleConfigurationProvider
        {
            siloBuilder.AddStartupTask<LoadCredentials>();
            siloBuilder.Services.AddSingleton<IGoogleConfigurationProvider, TGoogleProvider>();
            siloBuilder.Services.AddGooglePushNotifications(new GoogleConfiguration());
        }

        public static void AddAndroidPushNotifications<TGoogleProvider>(this ISiloBuilder siloBuilder)
            where TGoogleProvider : class, IGoogleConfigurationProvider
        {
            siloBuilder.AddStartupTask<LoadCredentials>();
            siloBuilder.Services.AddSingleton<IGoogleConfigurationProvider, TGoogleProvider>();
            siloBuilder.Services.AddGooglePushNotifications(new GoogleConfiguration());
        }

        public static void AddAndroidPushNotifications(this IServiceCollection serviceCollection,
            GoogleConfiguration config)
        {
            serviceCollection.AddGooglePushNotifications(config);
        }
    }
}
