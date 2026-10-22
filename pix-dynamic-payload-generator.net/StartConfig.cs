using pix_dynamic_payload_generator.net.Models.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace pix_dynamic_payload_generator.net
{
    public class StartConfig
    {

        public static string BaseUrl { get; private set; }

        public static string ClientId { get; private set; }

        public static string ClientSecret { get; private set; }

        public static X509Certificate2 Certificate { get; private set; }

        public StartConfig(string _baseUrl, string _clientId, string _clientSecret, X509Certificate2 _certificate)
        {
            BaseUrl = _baseUrl;
            ClientId = _clientId;
            ClientSecret = _clientSecret;
            Certificate = _certificate;
        }

        public StartConfig(IStartConfig _startConfig)
        {
            BaseUrl = _startConfig.BaseURL;
            ClientId = _startConfig.ClientId;
            ClientSecret = _startConfig.ClientSecret;
            Certificate = _startConfig.Certificate;
        }
    }
}
