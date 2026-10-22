using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_payload_generator.net;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class StaticQrCodeTest
    {
        [TestMethod]
        public void GeneratesPayloadWithoutPspCredentials()
        {
            var charge = new Cobranca(_chave: Guid.NewGuid().ToString());
            var payload = charge.ToPayload("TEST", new Merchant("TEST MERCHANT", "TEST CITY"));
            var result = payload.GenerateStringToQrCode();
            Assert.IsFalse(string.IsNullOrWhiteSpace(result));
            Assert.IsTrue(result.StartsWith("000201"));
            Assert.IsTrue(
                result.Contains("BR.GOV.BCB.PIX", StringComparison.OrdinalIgnoreCase),
                "The generated payload must contain the Pix GUI identifier.");
        }
    }
}

