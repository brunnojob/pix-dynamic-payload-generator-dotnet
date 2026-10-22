using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using pix_dynamic_payload_generator.net.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{

    public class PixRequestService : RequestBase
    {
        public PixRequestService()
        {
            SetRoute("pix");
        }

        public async Task<Pix> GetByE2eid(string e2eid)
        {
            return await GetAsync<Pix>("/" + e2eid);
        }

        public async Task<PixConsultaResponse> GetByPeriod(DateTime startDate, DateTime? endDate = null)
        {
            endDate = endDate ?? startDate.AddHours(24);

            return await GetAsync<PixConsultaResponse>("?inicio=" + startDate.ToString("u") + "&fim=" + endDate.Value.ToString("u"));
        }

        public async Task<PixDevolutionRequestResponse> RequestDevolution(string e2eid, string id, PixDevolutionRequest pixDevolutionRequest)
        {
            return await PutAsync<PixDevolutionRequestResponse>("/" + e2eid + "/devolucao/" + id, pixDevolutionRequest);
        }

        public async Task<PixDevolutionRequestResponse> GetDevolution(string e2eid, string id)
        {
            return await GetAsync<PixDevolutionRequestResponse>("/" + e2eid + "/devolucao/" + id);
        }
    }
}
