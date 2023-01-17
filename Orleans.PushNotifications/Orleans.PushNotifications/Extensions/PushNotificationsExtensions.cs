using Orleans.PushNotifications.Apple.Senders.Interfaces;
using Orleans.PushNotifications.Apple.Senders;
using Orleans.PushNotifications.Core.Interfaces;
using Orleans.PushNotifications.Core;
using Orleans.PushNotifications.Google.Senders.Interfaces;
using Orleans.PushNotifications.Google.Senders;
using Orleans.PushNotifications.Apple.Models;
using Orleans.PushNotifications.Google.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Orleans.PushNotifications.Extensions;

public static class PushNotificationsExtensions
{
    public static IServiceCollection AddApplePushNotifications(this IServiceCollection serviceCollection, AppleConfiguration config)
    {
        serviceCollection.AddSingleton<AppleConfiguration>(config);
        serviceCollection.AddSingleton<IApplePushSender, ApplePushSender>();
        serviceCollection.AddSingleton<IPushNotificationsManager, PushNotificationsManager>();

        return serviceCollection;
    }

    public static IServiceCollection AddGooglePushNotifications(this IServiceCollection serviceCollection, GoogleConfiguration config)
    {
        if (config is null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        serviceCollection.AddSingleton<GoogleConfiguration>(config);
        serviceCollection.AddSingleton<IGooglePushSender, GooglePushSender>();
        serviceCollection.TryAddSingleton<IPushNotificationsManager, PushNotificationsManager>();

        return serviceCollection;
    }

    //Microsoft.Extensions.Configuration
    /*public static IServiceCollection AddPushNotifications(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        AppleConfiguration  AppleConfiguration = configuration.GetSection(nameof(AppleConfiguration)).Bind<AppleConfiguration>();
        GoogleConfiguration  GoogleConfiguration = configuration.GetSection(nameof(GoogleConfiguration)).Bind(GoogleConfiguration);

        serviceCollection.AddSingleton<AppleConfiguration>(AppleConfiguration);
        serviceCollection.AddSingleton<GoogleConfiguration>(GoogleConfiguration);
        serviceCollection.AddSingleton<IApplePushSender, ApplePushSender>();
        serviceCollection.AddSingleton<IGooglePushSender, GooglePushSender>();
        serviceCollection.TryAddSingleton<IPushNotificationsManager, PushNotificationsManager>();

        return serviceCollection;
    }*/

    public static IServiceCollection AddPushNotifications(this IServiceCollection serviceCollection, AppleConfiguration AppleConfiguration, GoogleConfiguration GoogleConfiguration)
    {
        serviceCollection.AddSingleton<AppleConfiguration>(AppleConfiguration);
        serviceCollection.AddSingleton<GoogleConfiguration>(GoogleConfiguration);
        serviceCollection.AddSingleton<IApplePushSender, ApplePushSender>();
        serviceCollection.AddSingleton<IGooglePushSender, GooglePushSender>();
        serviceCollection.AddSingleton<IPushNotificationsManager, PushNotificationsManager>();

        return serviceCollection;
    }

    public static IServiceCollection AddPushNotifications(this IServiceCollection serviceCollection, GoogleConfiguration GoogleConfiguration, AppleConfiguration AppleConfiguration)
    {
        serviceCollection.AddSingleton<AppleConfiguration>(AppleConfiguration);
        serviceCollection.AddSingleton<GoogleConfiguration>(GoogleConfiguration);
        serviceCollection.AddSingleton<IApplePushSender, ApplePushSender>();
        serviceCollection.AddSingleton<IGooglePushSender, GooglePushSender>();
        serviceCollection.AddSingleton<IPushNotificationsManager, PushNotificationsManager>();

        return serviceCollection;
    }

    public static IServiceCollection AddFakePushNotifications(this IServiceCollection serviceCollection)
    {
        serviceCollection.RemoveAll<AppleConfiguration>();
        serviceCollection.RemoveAll<GoogleConfiguration>();
        serviceCollection.RemoveAll<IApplePushSender>();
        serviceCollection.RemoveAll<IGooglePushSender>();
        serviceCollection.RemoveAll<ApplePushSender>();
        serviceCollection.RemoveAll<GooglePushSender>();
        serviceCollection.RemoveAll<IPushNotificationsManager>();
        serviceCollection.RemoveAll<PushNotificationsManager>();

        // TODO: Decide what to do with test
        //serviceCollection.AddSingleton<IPushNotificationsManager, FakePushNotificationsManager>();

        return serviceCollection;
    }
}