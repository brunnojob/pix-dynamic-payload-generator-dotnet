using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.ApiResource
{

    public interface IHttpClientWrapper : IDisposable
    {

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }

    public class StandardHttpClient : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public StandardHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(StartConfig.Certificate);

            var token = Requests.RequestServices.TokenService.Create(); 

            client = new HttpClient(handler);
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
            return response;
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
