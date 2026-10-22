using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices.Base
{
    public interface IRequestBase : IDisposable
    {

        Task<T> GetAsync<T>(object data);

        Task<T> PostAsync<T>(object data, Dictionary<string, string> headers);
    }
}
