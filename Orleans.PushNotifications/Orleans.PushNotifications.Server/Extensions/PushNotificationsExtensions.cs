using Microsoft.Extensions.DependencyInjection;
using Orleans.PushNotifications.Apple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orleans.PushNotifications.Server.Extensions
{
    public class PushNotificationsExtensions
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
    }
}
