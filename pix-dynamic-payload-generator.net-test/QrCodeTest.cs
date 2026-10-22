using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using pix_dynamic_payload_generator.net.Models;
using pix_payload_generator.net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    [TestCategory("Integration")]
    public class QrCodeTest : UnitTestBase
    {

        [TestMethod]
        public async Task QrCodeGetDynamic()
        {
            var cobRequest = new CobRequestService();

            var cob = await cobRequest.GetByTxId(StartConfigValues.Required("PIX_TXID"));

            var payload = cob.ToPayload(new Merchant(StartConfigValues.Required("PIX_MERCHANT_NAME"), StartConfigValues.Required("PIX_MERCHANT_CITY")));

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

    }
}
