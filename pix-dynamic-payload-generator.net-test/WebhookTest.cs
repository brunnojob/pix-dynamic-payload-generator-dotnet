using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    [TestCategory("Integration")]
    public class WebhookTest : UnitTestBase
    {
        [TestMethod]
        public async Task WebhookCreate()
        {
            var request = new WebHookRequestService();
            var webHookRequest = new WebHookRequest
            {
                WebhookUrl = StartConfigValues.Required("PIX_WEBHOOK_URL")
            };
            var success = await request.Create(StartConfigValues.Required("PIX_KEY"), webHookRequest);
        }

        [TestMethod]
        public async Task WebhookGetByKey()
        {
            var request = new WebHookRequestService();
            var wh = await request.GetByKey(StartConfigValues.Required("PIX_KEY"));
        }
    }
}
