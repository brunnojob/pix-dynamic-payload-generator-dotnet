using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.CobrancaModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Requests.RequestModels.Base
{
    public class CobBaseRequest : Cobranca
    {
        public CobBaseRequest(string _chave) : base(_chave)
        {
        }

    }
}
