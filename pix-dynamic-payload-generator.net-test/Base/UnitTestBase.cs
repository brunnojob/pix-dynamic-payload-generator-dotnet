using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net;
using pix_dynamic_payload_generator.net.Models.Interfaces;
using System;
using System.Security.Cryptography.X509Certificates;

namespace pix_dynamic_payload_generator.net_test.Base
{
    public class UnitTestBase
    {
        [TestInitialize]
        public void ConfigureIntegration()
        {
            if (Environment.GetEnvironmentVariable("PIX_ENABLE_INTEGRATION") != "true")
                Assert.Inconclusive("Set PIX_ENABLE_INTEGRATION=true to run PSP integration tests.");

            new StartConfig(new StartConfigValues());
        }
    }

    public class StartConfigValues : IStartConfig
    {
        public static string Required(string name)
        {
            var value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidOperationException("Missing environment variable: " + name);
            return value;
        }

        public string BaseURL => Required("PIX_BASE_URL");
        public string ClientId => Required("PIX_CLIENT_ID");
        public string ClientSecret => Required("PIX_CLIENT_SECRET");
        public X509Certificate2 Certificate => new X509Certificate2(
            Required("PIX_CERTIFICATE_PATH"),
            Environment.GetEnvironmentVariable("PIX_CERTIFICATE_PASSWORD"));
    }
}
