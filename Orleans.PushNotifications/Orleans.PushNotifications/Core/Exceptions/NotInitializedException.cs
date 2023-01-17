namespace Orleans.PushNotifications.Core.Exceptions;

public class NotInitializedException : Exception
{
    public NotInitializedException() : base("Push provider is not initialized.")
    {
    }

    public NotInitializedException(string provider) : base($"Push provider {provider} is not initialized.")
    {
    }
}