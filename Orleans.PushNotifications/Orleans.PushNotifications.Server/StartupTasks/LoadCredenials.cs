using Orleans.Runtime;

namespace Orleans.PushNotifications.Server.StartupTasks
{
    public class LoadCredenials : IStartupTask
    {
        public Task Execute(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starup task");
            return Task.CompletedTask;
        }
    }
}
