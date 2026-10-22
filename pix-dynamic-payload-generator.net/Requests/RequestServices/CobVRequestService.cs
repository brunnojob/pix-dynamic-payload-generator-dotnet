using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{

    public class CobVRequestService : RequestBase
    {
        public CobVRequestService()
        {
            SetRoute("cobv");
        }

        public async Task<Cob> Create(string txId, CobVRequest cob)
        {
            return await PutAsync<Cob>("/" + txId, cob);
        }

        public async Task<Cob> GetByTxId(string txId)
        {
            return await GetAsync<Cob>("/" + txId);
        }
    }
}
