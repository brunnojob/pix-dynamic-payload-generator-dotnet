using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using pix_dynamic_payload_generator.net.Responses;
using System;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{

    public class CobRequestService : RequestBase
    {
        public CobRequestService()
        {
            SetRoute("cob");
        }

        public async Task<Cob> Create(CobRequest cob)
        {
            return await PostAsync<Cob>(cob);
        }

        public async Task<Cob> Create(string txId, CobRequest cob)
        {
            return await PutAsync<Cob>("/" + txId, cob);
        }

        public async Task<Cob> GetByTxId(string txId)
        {
            return await GetAsync<Cob>("/" + txId);
        }

        public async Task<CobConsultaResponse> GetByPeriod(DateTime startDate, DateTime? endDate = null)
        {
            endDate = endDate ?? startDate.AddHours(24);

            return await GetAsync<CobConsultaResponse>("?inicio=" + startDate.ToString("u") + "&fim=" + endDate.Value.ToString("u"));
        }
    }
}
