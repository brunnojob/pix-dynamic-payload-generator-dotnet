using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{

    public class WebHookRequestService : RequestBase
    {
        public WebHookRequestService()
        {
            SetRoute("webhook");
        }

        public async Task<bool> Create(string key, WebHookRequest request)
        {
            return await PutAsync<bool>("/" + key, request);
        }

        public async Task<Webhook> GetByKey(string key)
        {
            return await GetAsync<Webhook>("/" + key);
        }
    }
}
