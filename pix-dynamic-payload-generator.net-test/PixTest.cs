using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class PixTest : UnitTestBase
    {
        [TestMethod]
        public async Task GetByE2eid()
        {
            var request = new PixRequestService();
            var model = await request.GetByE2eid(StartConfigValues.Required("PIX_E2E_ID"));

            Assert.IsFalse(string.IsNullOrEmpty(model?.Txid));
        }

        [TestMethod]
        public async Task GetByPeriod()
        {
            var request = new PixRequestService();
            var model = await request.GetByPeriod(DateTime.Today);

            Assert.IsTrue(model.Parametros.Paginacao != null);
        }

        [TestMethod]
        public async Task RequestDevolution()
        {
            var request = new PixRequestService();
            var model = await request.RequestDevolution(StartConfigValues.Required("PIX_E2E_ID"), StartConfigValues.Required("PIX_REFUND_ID"), new net.Requests.RequestModels.PixDevolutionRequest
            {
                Valor = "0.06"
            });

            Assert.IsFalse(string.IsNullOrEmpty(model?.Id));
        }

        [TestMethod]
        public async Task GetDevolution()
        {
            var request = new PixRequestService();
            var model = await request.GetDevolution(StartConfigValues.Required("PIX_E2E_ID"), StartConfigValues.Required("PIX_REFUND_ID"));

            Assert.IsFalse(string.IsNullOrEmpty(model?.Id));
        }
    }
}
