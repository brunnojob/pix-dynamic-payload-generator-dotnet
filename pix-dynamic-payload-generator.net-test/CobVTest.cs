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
    public class CobVTest : UnitTestBase
    {

        [TestMethod]
        public async Task CobVCreate()
        {
            var cob = new CobVRequest
            {
                Chave = StartConfigValues.Required("PIX_KEY"),
                Calendario = new CalendarioCobV
                {
                    DataDeVencimento = "2020-12-31",
                    ValidadeAposVencimento = 30
                },
                Loc = new LocCobV
                {
                    Id = 789
                },
                Devedor = new DevedorCobV
                {
                    Logradouro = StartConfigValues.Required("PIX_DEBTOR_ADDRESS"),
                    Cidade = StartConfigValues.Required("PIX_DEBTOR_CITY"),
                    Uf = StartConfigValues.Required("PIX_DEBTOR_STATE"),
                    Cep = StartConfigValues.Required("PIX_DEBTOR_POSTAL_CODE"),
                    Cpf = StartConfigValues.Required("PIX_DEBTOR_CPF"),
                    Nome = StartConfigValues.Required("PIX_DEBTOR_NAME")
                },
                ValorCobV = new ValorCobV
                {
                    Original = "123.45",
                    Multa = new Multa
                    {
                        Modalidade = "2",
                        ValorPerc = "15.00"
                    },
                    Juros = new Juros
                    {
                        Modalidade = "2",
                        ValorPerc = "2.00"
                    },
                    Desconto = new Desconto
                    {
                        Modalidade = "1",
                        DescontoDataFixa = new System.Collections.Generic.List<DescontoDataFixa>
                        {
                            new DescontoDataFixa{ Data = "2020-11-30",ValorPerc = "30.00"}
                        }
                    }
                },
                SolicitacaoPagador = "Cobrança dos serviços prestados."
            };

            var cobRequest = new CobVRequestService();

            var cb = await cobRequest.Create(System.Guid.NewGuid().ToString("N"), cob);

            Assert.IsFalse(string.IsNullOrEmpty(cb?.Txid));
        }
    }
}
