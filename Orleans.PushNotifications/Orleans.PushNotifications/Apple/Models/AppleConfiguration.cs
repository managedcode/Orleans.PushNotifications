using Orleans.PushNotifications.Apple.Models.Enums;

namespace Orleans.PushNotifications.Apple.Models;

public class AppleConfiguration
{
    public int TokenExpiration { get; set; } = 50;

    /// <summary>
    ///     p8 certificate string
    /// </summary>
    public string P8PrivateKey { get; set; }

    /// <summary>
    ///     10 digit p8 certificate id. Usually a part of a downloadable certificate filename
    /// </summary>
    public string P8PrivateKeyId { get; set; }

    /// <summary>
    ///     Apple 10 digit team id
    /// </summary>
    public string TeamId { get; set; }

    /// <summary>
    ///     App slug / bundle name
    /// </summary>
    public string AppBundleIdentifier { get; set; }

    /// <summary>
    ///     Development or Production server
    /// </summary>
    public ApnServerType ApnServerType { get; set; }


    public void Validate()
    {
        ArgumentNullException.ThrowIfNull(P8PrivateKey);
        ArgumentNullException.ThrowIfNull(P8PrivateKeyId);
        ArgumentNullException.ThrowIfNull(TeamId);
        ArgumentNullException.ThrowIfNull(AppBundleIdentifier);

        if (TokenExpiration < 20 || TokenExpiration > 60)
        {
            throw new InvalidOperationException($"{nameof(TokenExpiration)} must be between 20-60 minutes");
        }
    }
}