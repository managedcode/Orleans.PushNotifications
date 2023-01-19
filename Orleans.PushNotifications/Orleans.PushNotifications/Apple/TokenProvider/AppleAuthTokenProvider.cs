using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Orleans.PushNotifications.Apple.Models;

namespace Orleans.PushNotifications.Apple.TokenProvider;

public sealed class AppleAuthTokenProvider
{
    private readonly Dictionary<string, Tuple<string, DateTime>> _tokens = new();
    private readonly AppleConfiguration _configuration;

    public AppleAuthTokenProvider(AppleConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetAuthToken()
    {

        lock (_tokens)
        {
            if (_tokens.TryGetValue(_configuration.AppBundleIdentifier, out var token))
            {
                if (token.Item2 > DateTime.UtcNow)
                {
                    return token.Item1;
                }
            }

            var newToken = CreateJwtToken();
            _tokens[_configuration.AppBundleIdentifier] = new Tuple<string, DateTime>(newToken, DateTime.UtcNow.AddMinutes(_configuration.TokenExpiration));
            return newToken;

        }
    }

    private string CreateJwtToken()
    {
        var header = JsonSerializer.Serialize(new { alg = "ES256", kid = CleanP8Key(_configuration.P8PrivateKeyId) });
        var payload = JsonSerializer.Serialize(new { iss = _configuration.TeamId, iat = ToEpoch(DateTime.UtcNow) });
        var headerBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(header));
        var payloadBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
        var unsignedJwtData = $"{headerBase64}.{payloadBase64}";
        var unsignedJwtBytes = Encoding.UTF8.GetBytes(unsignedJwtData);

        using (var dsa = GetEllipticCurveAlgorithm(CleanP8Key(_configuration.P8PrivateKey)))
        {
            var signature = dsa.SignData(unsignedJwtBytes, 0, unsignedJwtBytes.Length, HashAlgorithmName.SHA256);
            return $"{unsignedJwtData}.{Convert.ToBase64String(signature)}";
        }
    }

    private static ECDsa GetEllipticCurveAlgorithm(string privateKey)
    {
        var keyParams = (ECPrivateKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));
        var q = keyParams.Parameters.G.Multiply(keyParams.D).Normalize();

        return ECDsa.Create(new ECParameters
        {
            Curve = ECCurve.CreateFromValue(keyParams.PublicKeyParamSet.Id),
            D = keyParams.D.ToByteArrayUnsigned(),
            Q =
            {
                X = q.XCoord.GetEncoded(),
                Y = q.YCoord.GetEncoded()
            }
        });
    }

    private static int ToEpoch(DateTime time)
    {
        var span = time - new DateTime(1970, 1, 1);
        return Convert.ToInt32(span.TotalSeconds);
    }

    private static string CleanP8Key(string p8Key)
    {
        // If we have an empty p8Key, then don't bother doing any tasks.
        if (string.IsNullOrEmpty(p8Key))
        {
            return p8Key;
        }

        var lines = p8Key.Split(new[] { '\n' }).ToList();

        if (0 != lines.Count && lines[0].StartsWith("-----BEGIN PRIVATE KEY-----"))
        {
            lines.RemoveAt(0);
        }

        if (0 != lines.Count && lines[lines.Count - 1].StartsWith("-----END PRIVATE KEY-----"))
        {
            lines.RemoveAt(lines.Count - 1);
        }

        var result = string.Join(string.Empty, lines);

        return result;
    }
}